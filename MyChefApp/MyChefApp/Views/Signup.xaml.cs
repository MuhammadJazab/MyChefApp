using MyChefApp.Models;
using MyChefApp.Services;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyChefApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Signup : ContentPage
    {
        AuthServices authServices;

        public Signup()
        {
            InitializeComponent();

            authServices = new AuthServices();
        }
        
        private async void SignInClick(object sender, EventArgs e)
        {
            RegistrationModel registrationModel = new RegistrationModel()
            {
                Email = txtEmail.Text.ToLower(),
                Password = txtPassword.Text,
                UserName = txtUserName.Text
            };

            await authServices.RegisterUser(registrationModel);

            //await Navigation.PushAsync(new Account());
        }
    }
}