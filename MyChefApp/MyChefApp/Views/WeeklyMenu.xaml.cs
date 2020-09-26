using MyChefApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyChefApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeeklyMenu : ContentPage
    {
        UserVM userVM;

        public WeeklyMenu(UserVM userVM)
        {
            InitializeComponent();

            this.userVM = userVM;
        }

        private async void WeekMenu(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuPage());
        }
    }
}