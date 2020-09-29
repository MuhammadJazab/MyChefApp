
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyChefApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuRecipe : ContentPage
    {
        long menuId = 0;

        public MenuRecipe(long _menuId)
        {
            InitializeComponent();

            menuId = _menuId;
        }
    }
}