using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyChefApp.ViewModels
{
    public class ChatVM: INotifyPropertyChanged
    {
        public ObservableCollection<MessageVM> Messages { get; set; } = new ObservableCollection<MessageVM>();
        public string TextToSend { get; set; }
        public ICommand OnSendCommand { get; set; }

        public ChatVM()
        {
            Messages.Add(new MessageVM() { Text = "Hi" });
            Messages.Add(new MessageVM() { Text = "How are you?" });

            OnSendCommand = new Command(() =>
            {
                if (!string.IsNullOrEmpty(TextToSend))
                {
                    Messages.Add(new MessageVM() { Text = TextToSend, User = App.User });
                    TextToSend = string.Empty;
                }

            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}