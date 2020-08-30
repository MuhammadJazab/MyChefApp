using MyChefApp.Templates;
using System;
using Xamarin.Forms;

namespace MyChefApp.ControlHelpers
{
    public class DayTemplateSelector : DataTemplateSelector
    {
        DataTemplate EvenMenuItem, OddMenuItem;

        int dayCounter = 0;

        public DayTemplateSelector()
        {
            EvenMenuItem = new DataTemplate(typeof(EvenDays));
            OddMenuItem = new DataTemplate(typeof(OddDays));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            ++dayCounter;

            return dayCounter % 2 == 0 ? EvenMenuItem : OddMenuItem;
        }
    }
}
