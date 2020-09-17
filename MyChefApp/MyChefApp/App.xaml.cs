using Firebase.Database;
using MyChefApp.Views;
using Syncfusion.Licensing;
using Xamarin.Forms;

namespace MyChefApp
{
    public partial class App : Application
    {
        public App()
        {
            SyncfusionLicenseProvider.RegisterLicense("MzAzNTI5QDMxMzgyZTMyMmUzMGhJWGVNK0N6aUdUdmVySHo0YnhjZzIwSkZSemJzNUlTZFlvbS9aN2lUZ009");

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
