using MyChefApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
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
                return ((Chat)item).Role.Equals(1) ? FromTemplate : ToTemplate;
            }
            else
            {
                return ToTemplate;
            }
        }
    }
}
