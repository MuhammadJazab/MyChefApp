using System.Threading.Tasks;
using Android;
using Android.App;
using Android.OS;

namespace MyChefApp.Droid
{
    [Activity(MainLauncher = true, NoHistory = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class SplashScreen : Activity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SplashScreen);

            await Task.Delay(500);

            StartActivity(typeof(MainActivity));
            Finish();
        }
    }
}