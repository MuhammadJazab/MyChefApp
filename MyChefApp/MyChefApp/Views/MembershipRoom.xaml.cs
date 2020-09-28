using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyChefApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MembershipRoom : ContentPage
    {
        public MembershipRoom()
        {
            InitializeComponent();
        }

        private async void BOHTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyCheffCommunity());
        }
    }
}