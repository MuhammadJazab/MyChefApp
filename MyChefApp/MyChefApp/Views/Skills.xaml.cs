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
        long accountType;

        public Skills(long accountType)
        {
            this.accountType = accountType;

            InitializeComponent();
        }

        private async void SelectSkill(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyDiet(accountType, Convert.ToInt64(((TappedEventArgs)e).Parameter)));
        }
    }
}