using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyChefApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeeklyMenu : ContentPage
    {
        public WeeklyMenu()
        {
            InitializeComponent();

            //Application.Current.Resources["resourceName"]
        }

        private void WeekMenu(object sender, EventArgs e)
        {

        }
    }
}