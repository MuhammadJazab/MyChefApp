using MyChefApp.Services;
using MyChefApp.ViewModels;
using Newtonsoft.Json;
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
        }

        private async Task FatchAndBindData()
        {
            Response cookingSkillsJson = await httpRequests.GetCookingSkills();

            List<CookingSkillVM> cookingSkills = JsonConvert.DeserializeObject<List<CookingSkillVM>>(cookingSkillsJson.ResultData.ToString());
            string skill = cookingSkills.Where(x => x.CookingSkillId == userVM.CookingSkillId).FirstOrDefault().CookingSkillName;

            NameContainer.IsVisible = true;

            Lbl_Name.Text = $"WELCOME, {userVM.UserName}";
            ButtonXPLevel.Text = $"Xp level: {skill}";
        }

        private async void WeekMenu(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuPage());
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