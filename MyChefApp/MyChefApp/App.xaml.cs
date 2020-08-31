using MyChefApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyChefApp
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzAzNTI5QDMxMzgyZTMyMmUzMGhJWGVNK0N6aUdUdmVySHo0YnhjZzIwSkZSemJzNUlTZFlvbS9aN2lUZ009");

            InitializeComponent();

            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
