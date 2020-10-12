using MyChefApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyChefApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Account : ContentPage
    {
        UserVM userVM;

        public Account(UserVM _userVM)
        {
            InitializeComponent();

            userVM = _userVM;
        }

        private async void ClickPaymentMethod(object sender, EventArgs e)
        {
            switch (Convert.ToInt64(((TappedEventArgs)e).Parameter))
            {
                case 1:
                    userVM.AccountTypeId = Convert.ToInt64(((TappedEventArgs)e).Parameter);
                    if (userVM.CookingSkillId < 0)
                        await Navigation.PushAsync(new Skills(userVM));
                    else
                        await Navigation.PushAsync(new WeeklyMenu(userVM));
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