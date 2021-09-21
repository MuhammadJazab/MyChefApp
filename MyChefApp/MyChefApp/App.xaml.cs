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
            SyncfusionLicenseProvider.RegisterLicense("MzM0NzI0QDMxMzgyZTMzMmUzMG1GWVZlbDVvanZVQXRaeWJEbUxKa25DUXZtTzNQRkNKSGVuRng2S05jRDQ9");

            InitializeComponent();

            MainPage = new NavigationPage(new GallaryPage(new UserVM()));
            //SessionManagement.LoginMechanism();
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
