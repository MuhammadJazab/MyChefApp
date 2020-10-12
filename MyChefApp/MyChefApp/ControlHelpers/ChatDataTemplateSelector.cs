using MyChefApp.ViewModels;
using Xamarin.Forms;

namespace MyChefApp.ControlHelpers
{
    public class ChatDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FromTemplate { get; set; }
        public DataTemplate ToTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item != null)
            {
                return ((Chat)item).Role.Equals(App.UserId) ? FromTemplate : ToTemplate;
            }
            else
            {
                return ToTemplate;
            }
        }
    }
}
