
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

        private async void ItemTapped_WeeklyMenu(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new MenuRecipe());
        }
    }
}