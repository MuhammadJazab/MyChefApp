using MyChefApp.Services;
using MyChefApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyChefApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        HttpRequests httpRequests;

        public Login()
        {
            InitializeComponent();

            httpRequests = new HttpRequests();
        }

        private async void ForgotUserPasswordClick(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Under Development", "OK");
        }

        private async void LoginClick(object sender, EventArgs e)
        {
            Busy();

            UserVM signIn = new UserVM()
            {
                Email = txtEmail.Text,
                Password = txtPassword.Text,
                IsAdmin = false
            };

            Response response = await httpRequests.GetUserByCredentials(signIn);

            if (response != null)
            {
                if (response.Status == ResponseStatus.Restrected)
                {
                    ContainerEmail.HasError = true;
                    ContainerPassword.HasError = true;

                    ContainerEmail.ErrorColor = Color.Red;
                    ContainerPassword.ErrorColor = Color.Red;

                    ContainerEmail.ErrorText = response.Message;
                    ContainerPassword.ErrorText = response.Message;
                }
                else if (response.Status == ResponseStatus.Error)
                {
                    await DisplayAlert("Error", "Unable to connect to the server. Check your internet connection", "OK");
                }
                else
                {
                    await SessionManagement.SetSession(SessionKey.Token, $"{response.ResultData} ");
                    SessionManagement.LoginMechanism();
                }
            }
            else
            {
                await DisplayAlert("Error", "Unable to connect to the server. Check your internet connection", "OK");
            }

            NotBusy();
        }

        private async void SignupClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Signup());
        }

        public void Busy()
        {
            ActivityIndicator.IsVisible = true;
            ActivityIndicator.IsRunning = true;

            txtEmail.IsEnabled = false;
            txtPassword.IsEnabled = false;
            Btn_Login.IsEnabled = false;
        }

        public void NotBusy()
        {
            ActivityIndicator.IsVisible = false;
            ActivityIndicator.IsRunning = false;

            txtEmail.IsEnabled = true;
            txtPassword.IsEnabled = true;
            Btn_Login.IsEnabled = true;
        }
    }
}