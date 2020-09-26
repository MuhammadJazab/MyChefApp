using Firebase.Database;
using MyChefApp.Services;
using MyChefApp.ViewModels;
using MyChefApp.Views;
using Newtonsoft.Json;
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

            //if (!string.IsNullOrEmpty(SessionManagement.GetSession(SessionKey.Token)))
            //{
            //    UserVM user = JsonConvert.DeserializeObject<UserVM>(SessionManagement.GetSession(SessionKey.Token));

            //    if (user != null)
            //    {
            //        if (!string.IsNullOrEmpty(user.Email))
            //        {
            //            if (user.AccountType > 0)
            //            {
            //                if(user.CookingSkills > 0)
            //                {

            //                }
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    MainPage = new NavigationPage(new Login());
            //}

            //MainPage = new NavigationPage(new WeeklyMenu(new UserVM()));
            MainPage = new NavigationPage(new TestPage());
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
