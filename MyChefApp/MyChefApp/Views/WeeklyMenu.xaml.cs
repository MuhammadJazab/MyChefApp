using MyChefApp.Popups;
using MyChefApp.Services;
using MyChefApp.ViewModels;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyChefApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeeklyMenu : ContentPage
    {
        HttpRequests httpRequests;

        UserVM userVM;

        string skill;

        public WeeklyMenu(UserVM userVM)
        {
            InitializeComponent();

            httpRequests = new HttpRequests();

            this.userVM = userVM;

            Device.BeginInvokeOnMainThread(async () =>
            {
                ShowActivityIndicator();
                await FatchAndBindData();
                HideActivityIndicator();
            });

            Navigation.PopToRootAsync();
        }

        private async Task FatchAndBindData()
        {
            Response cookingSkillsJson = await httpRequests.GetCookingSkills();

            List<CookingSkillVM> cookingSkills = JsonConvert.DeserializeObject<List<CookingSkillVM>>(cookingSkillsJson.ResultData.ToString());
            skill = cookingSkills.Where(x => x.CookingSkillId == userVM.CookingSkillId).FirstOrDefault().CookingSkillName;

            NameContainer.IsVisible = true;

            Lbl_Name.Text = $"WELCOME, {userVM.UserName}";
            ButtonXPLevel.Text = $"Xp level: {skill}";
        }

        private async void WeekMenu(object sender, EventArgs e)
        {
            if (userVM.AccountTypeId != 1)
            {

                await Navigation.PushAsync(new MenuPage(userVM));
            }
            else
            {
                await DisplayAlert("Invalid access", "This option is not available for free account type. Kindly update your account.", "OK");
            }
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

        private async void ChefChallenges(object sender, EventArgs e)
        {
            if (userVM.AccountTypeId != 1)
            {

                await Navigation.PushAsync(new MenuRecipe(userVM, 1));
            }
            else
            {
                await DisplayAlert("Invalid access", "This option is not available for free account type. Kindly update your account.", "OK");
            }

        }

        private async void MYChefFolk(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MembershipRoom(userVM));
        }

        private async void Settings_Click(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new ContextMenuPopup(userVM));
        }

        async void PhotoGallery(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GallaryPage(userVM));
        }
    }
}