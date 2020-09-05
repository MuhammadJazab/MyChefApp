using MyChefApp.Models;
using MyChefApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyChefApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        AuthServices authServices;

        public Login()
        {
            InitializeComponent();

            authServices = new AuthServices();
        }

        private void ForgotUserPasswordClick(object sender, EventArgs e)
        {

        }

        private async void LoginClick(object sender, EventArgs e)
        {
            SignIn signIn = new SignIn()
            {
                Email = txtEmail.Text,
                Password = txtPassword.Text
            };

            Response response = await authServices.SignIn(signIn);

            if (response.Status == ResponseStatus.Restrected)
            {
                await DisplayAlert("Error", Messages.InvalidUsers, "OK");
            }
            else if (response.Status == ResponseStatus.Error)
            {
                await DisplayAlert("Error", "Unable to connect to the server. Check your internet connection", "OK");
            }
            else
            {
                await SessionManagement.SetSession(SessionKey.Token, $"{response.ResultData} ");
                await Navigation.PushAsync(new Account());
            }

        }

        private async void SignupClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Signup());
        }
    }
}