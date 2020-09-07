using Firebase.Database;
using MyChefApp.Views;
using Syncfusion.Licensing;
using Xamarin.Forms;

namespace MyChefApp
{
    public partial class App : Application
    {
        public static FirebaseClient firebaseClient = new FirebaseClient("https://mychef-app-c0406.firebaseio.com/");

        public App()
        {
            SyncfusionLicenseProvider.RegisterLicense("MzAzNTI5QDMxMzgyZTMyMmUzMGhJWGVNK0N6aUdUdmVySHo0YnhjZzIwSkZSemJzNUlTZFlvbS9aN2lUZ009");

            InitializeComponent();

            //MainPage = new NavigationPage(new Login());
            MainPage = new NavigationPage(new MyCheffCommunity());
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
