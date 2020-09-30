using MyChefApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyChefApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MembershipRoom : ContentPage
    {
        UserVM userVM;

        public MembershipRoom(UserVM userVM)
        {
            this.userVM = userVM;

            InitializeComponent();
        }

        private async void BOHTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChatPage(userVM, "BOH Chat Room"));
        }

        private async void CCTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChatPage(userVM, "CC Chat Room"));
        }

        private async void OTTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChatPage(userVM, "OT Chat Room"));
        }
    }
}