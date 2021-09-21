using System;
using MyChefApp.Services;
using MyChefApp.ViewModels;
using UIKit;

namespace MyChefApp.iOS.Services
{
    public class ScreenSizeDependency : IDeviceStatics
    {
        public DeviceStaticsVM GetDevice()
        {
            DeviceStaticsVM _helper = new DeviceStaticsVM
            {
                ScreenHeight = (int)UIScreen.MainScreen.Bounds.Height,
                ScreenWidth = (int)UIScreen.MainScreen.Bounds.Width
            };
            return _helper;
        }
    }
}
