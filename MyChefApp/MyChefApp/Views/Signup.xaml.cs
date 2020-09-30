﻿using MyChefApp.Services;
using MyChefApp.ViewModels;
using Newtonsoft.Json;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyChefApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Signup : ContentPage
    {
        HttpRequests authServices;

        public Signup()
        {
            InitializeComponent();

            authServices = new HttpRequests();
        }

        private async void SignInClick(object sender, EventArgs e)
        {
            ShowActivityIndicator();

            UserVM userVm = new UserVM()
            {
                Email = txtEmail.Text.ToLower(),
                Password = txtPassword.Text,
                UserName = txtUserName.Text
            };

            Response response = await authServices.RegisterUser(userVm);

            HideActivityIndicator();

            if (response.Status == ResponseStatus.OK)
            {
                await SessionManagement.SetSession(SessionKey.Token, $"{response.ResultData} ");
                await Navigation.PushAsync(new Account(JsonConvert.DeserializeObject<UserVM>(response.ResultData.ToString())));
            }
            else await DisplayAlert("Error", "Unable to connect to the server. Check your internet connection", "OK");
        }

        private void ShowActivityIndicator()
        {
            ActivityIndicator.IsVisible = true;
            ActivityIndicator.IsRunning = true;

            txtEmail.IsEnabled = false;
            txtPassword.IsEnabled = false;
            txtUserName.IsEnabled = false;
            Btn_SignIn.IsEnabled = false;
        }

        private void HideActivityIndicator()
        {
            ActivityIndicator.IsRunning = false;
            ActivityIndicator.IsVisible = false;

            txtEmail.IsEnabled = true;
            txtPassword.IsEnabled = true;
            txtUserName.IsEnabled = true;
            Btn_SignIn.IsEnabled = true;
        }
    }
}