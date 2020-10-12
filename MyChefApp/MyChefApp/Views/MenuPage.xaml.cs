using MyChefApp.Services;
using MyChefApp.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyChefApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        HttpRequests httpRequests;
        UserVM userVM;

        ObservableCollection<WeekMenuVM> menus;

        public MenuPage(UserVM _userVM)
        {
            InitializeComponent();

            httpRequests = new HttpRequests();
            userVM = _userVM;

            menus = new ObservableCollection<WeekMenuVM>();

            Device.BeginInvokeOnMainThread(async () =>
            {
                ShowActivityIndicator();
                await FatchAndBindData();
                HideActivityIndicator();
            });
        }

        private async Task FatchAndBindData()
        {
            Response response = await httpRequests.GetWeeklyMenu();

            List<WeekMenuVM> weekMenuList = JsonConvert.DeserializeObject<List<WeekMenuVM>>(response.ResultData.ToString());

            foreach (var item in weekMenuList)
            {
                menus.Add(item);
            }

            ListView_WeeklyMenu.ItemsSource = menus;

            MenuContainer.IsVisible = true;
        }

        private async void ItemTapped_WeeklyMenu(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new MenuRecipe(userVM, ((WeekMenuVM)e.Item).MenuId));
        }

        private void ShowActivityIndicator()
        {
            ActivityIndicator.IsVisible = true;
            ActivityIndicator.IsRunning = true;
        }

        private void HideActivityIndicator()
        {
            ActivityIndicator.IsRunning = false;
            ActivityIndicator.IsVisible = false;
        }
    }
}