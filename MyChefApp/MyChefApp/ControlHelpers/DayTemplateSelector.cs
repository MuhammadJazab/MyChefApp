using MyChefApp.Templates;
using MyChefApp.ViewModels;
using Xamarin.Forms;

namespace MyChefApp.ControlHelpers
{
    public class DayTemplateSelector : DataTemplateSelector
    {
        DataTemplate EvenMenuItem, OddMenuItem;

        public DayTemplateSelector()
        {
            EvenMenuItem = new DataTemplate(typeof(EvenDays));
            OddMenuItem = new DataTemplate(typeof(OddDays));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item == null)
                return EvenMenuItem;

            return ((WeekMenuVM)item).IsEven ? EvenMenuItem : OddMenuItem;
        }
    }
}
