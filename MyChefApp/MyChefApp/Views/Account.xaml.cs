using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyChefApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Account : ContentPage
    {
        public Account()
        {
            InitializeComponent();
        }

        private async void FreeClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Skills());
        }

        private async void PremiumClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Skills());
        }

        private async void FKPremiumClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Skills());
        }
    }
}