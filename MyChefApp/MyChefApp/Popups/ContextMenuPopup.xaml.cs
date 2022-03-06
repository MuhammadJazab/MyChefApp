using MyChefApp.Services;
using MyChefApp.ViewModels;
using MyChefApp.Views;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyChefApp.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContextMenuPopup : PopupPage
    {
        UserVM user = new UserVM();

        public ContextMenuPopup(UserVM userVM)
        {
            InitializeComponent();

            user = userVM;
        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        private async void Signout_Click(object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();

            SessionManagement.RemoveSession();
            SessionManagement.LoginMechanism();
            await Navigation.PopToRootAsync();
        }

        private async void Preferences_Click(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MyDiet(user));
            await PopupNavigation.Instance.PopAsync();
        }

        private async void Accounts_Click(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Account(user));
            await PopupNavigation.Instance.PopAsync();
        }
    }
}