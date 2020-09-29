using MyChefApp.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyChefApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Skills : ContentPage
    {
        UserVM userVM;

        public Skills(UserVM _userVM)
        {
            InitializeComponent();

            userVM = _userVM;
        }

        private async void SelectSkill(object sender, EventArgs e)
        {
            userVM.CookingSkillId = Convert.ToInt64(((TappedEventArgs)e).Parameter);

            await Navigation.PushAsync(new MyDiet(userVM));
        }
    }
}