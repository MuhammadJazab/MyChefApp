using MyChefApp.ViewModels;
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
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();

            ListView_WeeklyMenu.ItemsSource = new WeekMenu().GetMenu();
        }

        private void ItemTapped_WeeklyMenu(object sender, ItemTappedEventArgs e)
        {

        }
    }
}