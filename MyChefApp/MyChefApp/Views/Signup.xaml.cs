using MyChefApp.Services;
using MyChefApp.ViewModels;
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
            RegistrationVM registrationModel = new RegistrationVM()
            {
                Email = txtEmail.Text.ToLower(),
                Password = txtPassword.Text,
                UserName = txtUserName.Text
            };

            Response response =  await authServices.RegisterUser(registrationModel);

            if(response.Status == ResponseStatus.OK)
            {
                await SessionManagement.SetSession(SessionKey.Token, $"{response.ResultData} ");
                await Navigation.PushAsync(new Account());
            }
            else await DisplayAlert("Error", "Unable to connect to the server. Check your internet connection", "OK");
        }
    }
}