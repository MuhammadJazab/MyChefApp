using MyChefApp.Templates;
using Xamarin.Forms;

namespace MyChefApp.ControlHelpers
{
    class ChatTemplateSelector : DataTemplateSelector
    {
        DataTemplate incomingDataTemplate;
        DataTemplate outgoingDataTemplate;

        public ChatTemplateSelector()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(IncomingMessage));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingMessage));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            MessageVM messageVm = item as MessageVM;
            if (messageVm == null)
                return null;


            return (messageVm.User == App.User) ? outgoingDataTemplate : incomingDataTemplate;
        }

    }
}