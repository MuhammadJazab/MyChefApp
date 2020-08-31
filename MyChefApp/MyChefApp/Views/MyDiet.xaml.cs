using MyChefApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyChefApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyDiet : ContentPage
    {
        public MyDiet()
        {
            InitializeComponent();

            listView_MyProteins.ItemsSource = new Protien().GetProtiens();
            listView_MyGrains.ItemsSource = new Grain().GetGrain();
            listView_MyVeggies.ItemsSource = new Veggie().GetVeggie();
            listView_AllergieAndRestrictions.ItemsSource = new AllergieAndRestriction().GetAllergieAndRestrictions();

        }

        private void ItemTapped_MyProtein(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = (Protien)e.Item;
            selectedItem.IsSelected = selectedItem.IsSelected ? false : true;
        }

        private void ItemTapped_MyGrains(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = (Grain)e.Item;
            selectedItem.IsSelected = selectedItem.IsSelected ? false : true;
        }

        private void ItemTapped_MyVeggies(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = (Veggie)e.Item;
            selectedItem.IsSelected = selectedItem.IsSelected ? false : true;
        }

        private void ItemTapped_AllergieAndRestrictions(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = (AllergieAndRestriction)e.Item;
            selectedItem.IsSelected = selectedItem.IsSelected ? false : true;
        }

        private async void ClickedNext(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WeeklyMenu());
        }
    }
}