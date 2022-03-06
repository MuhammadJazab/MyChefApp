using MyChefApp.Services;
using MyChefApp.ViewModels;
using MyChefApp.Views;
using Syncfusion.Licensing;
using Xamarin.Forms;

namespace MyChefApp
{
    public partial class App : Application
    {
        public static long UserId = 0;

        public App()
        {
            SyncfusionLicenseProvider.RegisterLicense("NTkxODU2QDMxMzkyZTM0MmUzMFh3Yi9VVzRyS1NOa1RFQ3hFQTltQnpRdFRKUFc4Q01YZzVyV0VQWi9sckE9");

            InitializeComponent();

            //MainPage = new NavigationPage(new GallaryPage(new UserVM()));
            SessionManagement.LoginMechanism();
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
