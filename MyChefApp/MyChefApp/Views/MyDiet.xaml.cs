using MyChefApp.Services;
using MyChefApp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyChefApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyDiet : ContentPage
    {
        HttpRequests httpRequests;

        ObservableCollection<FoodVM> proteinList;
        ObservableCollection<FoodVM> grainList;
        ObservableCollection<FoodVM> vegiList;
        ObservableCollection<FoodVM> allergiesList;

        UserVM userVM;

        List<FoodVM> selectedFoods;

        public MyDiet(UserVM _userVM)
        {
            InitializeComponent();

            httpRequests = new HttpRequests();

            userVM =_userVM;

            selectedFoods = new List<FoodVM>();

            proteinList = new ObservableCollection<FoodVM>();
            grainList = new ObservableCollection<FoodVM>();
            vegiList = new ObservableCollection<FoodVM>();
            allergiesList = new ObservableCollection<FoodVM>();

            Device.BeginInvokeOnMainThread(async () =>
            {
                ShowActivityIndicator();
                await FatchAndBindData();
                HideActivityIndicator();
            });
        }

        private async Task FatchAndBindData()
        {
            Response response = await httpRequests.GetFoodList();

            List<FoodVM> foodVM = JsonConvert.DeserializeObject<List<FoodVM>>(response.ResultData.ToString());

            foreach (var item in foodVM.Where(x => x.FoodTypeId == (int)FoodTypeEnum.Protein))
            {
                proteinList.Add(item);
            }

            foreach (var item in foodVM.Where(x => x.FoodTypeId == (int)FoodTypeEnum.Grain))
            {
                grainList.Add(item);
            }

            foreach (var item in foodVM.Where(x => x.FoodTypeId == (int)FoodTypeEnum.Veggie))
            {
                vegiList.Add(item);
            }

            foreach (var item in foodVM.Where(x => x.FoodTypeId == (int)FoodTypeEnum.AllergieAndRestriction))
            {
                allergiesList.Add(item);
            }

            ContainerExpender.IsVisible = true;
            Btn_Next.IsEnabled = true;

            listView_MyProteins.ItemsSource = proteinList;
            listView_MyGrains.ItemsSource = grainList;
            listView_MyVeggies.ItemsSource = vegiList;
            listView_AllergieAndRestrictions.ItemsSource = allergiesList;
        }

        private void ItemTapped_FoodSelection(object sender, ItemTappedEventArgs e)
        {
            FoodVM selectedItem = (FoodVM)e.Item;
            selectedItem.IsSelected = !selectedItem.IsSelected;

            if (selectedItem.IsSelected)
                selectedFoods.Add(selectedItem);
            else selectedFoods.Remove(selectedItem);
        }

        private async void ClickedNext(object sender, EventArgs e)
        {
            if (selectedFoods.Count > 0)
            {
                userVM.UserFoodPreferences = selectedFoods;

                Response response = await httpRequests.UpdateUser(userVM);

                if (response.Status == ResponseStatus.OK)
                {
                    await SessionManagement.SetSession(SessionKey.Token, $"{response.ResultData} ");
                    await Navigation.PushAsync(new WeeklyMenu(userVM)); 
                }
                else
                    await DisplayAlert("Error", response.Message, "OK");
            }
            else await DisplayAlert("Alert", "Select atleast one food item", "OK");
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