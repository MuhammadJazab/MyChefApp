using Firebase.Database.Query;
using MyChefApp.Services;
using MyChefApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyChefApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        FirebaseHelper firebaseHelper;
        string chatRoom;
        ObservableCollection<Chat> chatList;
        List<Chat> completeList;
        //JobSvc jobSvc;

        public ChatPage(string chatRoom)
        {
            InitializeComponent();
            this.chatRoom = chatRoom;

            GetData();
        }

        private async void GetData()
        {
            //await CustomLoadingDialog.ShowLoadingDialog("Loading messages..");

            firebaseHelper = new FirebaseHelper();
            chatList = new ObservableCollection<Chat>();
            completeList = new List<Chat>();
            //jobSvc = new JobSvc();

            completeList = await firebaseHelper.GetCompleteChat(chatRoom);

            if (completeList?.Count > 0)
            {
                foreach (Chat item in completeList)
                {
                    chatList.Add(item);
                }
            }

            listMessages.ScrollTo(chatList, ScrollToPosition.MakeVisible, true);
            listMessages.ItemsSource = chatList;

            listMessages.IsVisible = true;

            subChat();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_msg.Text))
            {
                string message = txt_msg.Text;
                txt_msg.Text = string.Empty;

                Chat chat = new Chat()
                {
                    Message = message,
                    DateSent = DateTime.Now,
                    Role = 1,
                    Status = 2
                };

                await firebaseHelper.AddChat(chat, chatRoom);
                message = string.Empty;
            }
            else
            {
                //DependencyService.Get<IToastMessage>().ShortAlert("Can't send empty message");
            }
            //var allPersons = await firebaseHelper.GetAllPersons();
            //lstPersons.ItemsSource = allPersons;
        }


        public void subChat()
        {
            firebaseHelper.firebase
                .Child("Chats")
                .Child(chatRoom)
                .OrderByKey()
                .LimitToLast(1)
                .AsObservable<Chat>()
                .Subscribe(d => addToList(d.Object, d.Key));
        }

        private void addToList(Chat chat, string key)
        {
            try
            {
                if (chat != null && !(chatList.Count > 0 && chatList.LastOrDefault().DateSent.Ticks.Equals(chat.DateSent.Ticks)))
                {
                    chatList.Add(chat);

                    //InappChatVM chatVM = new InappChatVM()
                    //{
                    //    ChatKey = key,
                    //    ChatRoom = chatRoom,
                    //    DateSent = chat.DateSent,
                    //    Message = chat.Message,
                    //    StatusId = chat.Status,
                    //    UserRoleId = chat.Role
                    //};

                    //jobSvc.SaveUpdateInappChat(chatVM, new SessionManagment().GetSession()).Wait();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}