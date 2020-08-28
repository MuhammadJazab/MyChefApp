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

            listView_MyProteins.ItemsSource = new Protien().GetProtiens(); ;
        }
        
        private void ItemTapped_MyProtein(System.Object sender, ItemTappedEventArgs e)
        {

        }
    }
}