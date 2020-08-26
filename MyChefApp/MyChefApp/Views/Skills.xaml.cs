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
    public partial class Skills : ContentPage
    {
        public Skills()
        {
            InitializeComponent();
        }

        private async void SelectSkill(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyDiet());
        }
    }
}