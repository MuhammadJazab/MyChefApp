using System.Threading.Tasks;
using Android;
using Android.App;
using Android.OS;

namespace MyChefApp.Droid
{
    [Activity(MainLauncher = true, NoHistory = true, Theme = "@style/MainTheme", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class SplashScreen : Activity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SplashScreen);

            await Task.Delay(2000);

            StartActivity(typeof(MainActivity));
            Finish();
        }
    }
}