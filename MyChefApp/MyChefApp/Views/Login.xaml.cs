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
        public Login()
        {
            InitializeComponent();
        }

        private void ForgotUserPasswordClick(object sender, EventArgs e)
        {

        }

        private async void LoginClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Account());
        }

        private async void SignupClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Signup());
        }
    }
}