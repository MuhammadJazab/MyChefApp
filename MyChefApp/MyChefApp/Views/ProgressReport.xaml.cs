using MyChefApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyChefApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgressReport : ContentPage
    {
        public ProgressReport(UserVM userVM, string skill)
        {
            InitializeComponent();

            Lbl_XpLevel.Text = skill;
            Lbl_UserName.Text = userVM.UserName;

        }
    }
}