using MyChefApp.Services;
using MyChefApp.ViewModels;
using MyChefAppViewModels;
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
    public partial class MenuRecipe : ContentPage
    {
        HttpRequests httpRequests;
        UserVM userVM;

        long menuId = 0;

        public MenuRecipe(UserVM _userVM, long _menuId)
        {
            InitializeComponent();

            httpRequests = new HttpRequests();
            userVM = _userVM;

            menuId = _menuId;

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
            Response response = await httpRequests.GetRecipeByMenuId(menuId); 

            List<CookingSkillVM> cookingSkills = JsonConvert.DeserializeObject<List<CookingSkillVM>>(cookingSkillsJson.ResultData.ToString());

            string skill = cookingSkills.Where(x => x.CookingSkillId == userVM.CookingSkillId).FirstOrDefault().CookingSkillName;

            if (response.Status == ResponseStatus.OK)
            {
                RecipeVM recipeVM = JsonConvert.DeserializeObject<RecipeVM>(response.ResultData?.ToString());

                if (recipeVM != null && !string.IsNullOrEmpty(skill))
                {
                    Lbl_CookingSkillLevel.Text = skill;
                    Lbl_Day.Text = recipeVM.MenuDay;
                    Lbl_MenuName.Text = recipeVM.MenuTitle;
                    Lbl_PrepationSteps.Text = recipeVM.Directions;

                    foreach (var ingredient in recipeVM.RecipeIngredients)
                    {
                        Lbl_Ingredients.Text += $"{ingredient.MenuIngredients}, ";
                    }
                }
            }
            else
            {
                await DisplayAlert("Error", "Record not found", "OK");
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
    }
}