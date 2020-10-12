﻿using MyChefApp.Services;
using Syncfusion.Licensing;
using Xamarin.Forms;

namespace MyChefApp
{
    public partial class App : Application
    {
        public static long UserId = 0;

        public App()
        {
            SyncfusionLicenseProvider.RegisterLicense("MzAzNTI5QDMxMzgyZTMyMmUzMGhJWGVNK0N6aUdUdmVySHo0YnhjZzIwSkZSemJzNUlTZFlvbS9aN2lUZ009");

            InitializeComponent();

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
