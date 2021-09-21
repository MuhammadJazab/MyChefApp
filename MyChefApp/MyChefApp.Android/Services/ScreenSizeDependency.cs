using Android.Content.Res;
using MyChefApp.Droid.Services;
using MyChefApp.Services;
using MyChefApp.ViewModels;
using Xamarin.Forms;

[assembly: Dependency(typeof(ScreenSizeDependency))]
namespace MyChefApp.Droid.Services
{
    public class ScreenSizeDependency : IDeviceStatics
    {
        private int ConvertPixelsToDp(int pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.System.DisplayMetrics.Density);
            return dp;
        }

        public DeviceStaticsVM GetDevice()
        {
            var metrics = Resources.System.DisplayMetrics;

            DeviceStaticsVM _helper = new DeviceStaticsVM
            {
                ScreenHeight = ConvertPixelsToDp(metrics.HeightPixels),
                ScreenWidth = ConvertPixelsToDp(metrics.WidthPixels)
            };
            return _helper;
        }
    }
}
