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

        private async void ClickPaymentMethod(object sender, EventArgs e)
        {
            switch (Convert.ToInt64(((TappedEventArgs)e).Parameter))
            {
                case 1:
                    await Navigation.PushAsync(new Skills(Convert.ToInt64(((TappedEventArgs)e).Parameter)));
                    break;

                case 2:
                    await DisplayAlert("Error", "Payment method are under development", "OK");
                    break;

                case 3:
                    await DisplayAlert("Error", "Payment method are under development", "OK");
                    break;
                default:
                    break;
            }
        }
    }
}