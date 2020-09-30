﻿using Firebase.Database.Query;
using MyChefApp.Services;
using MyChefApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyChefApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        FirebaseHelper firebaseHelper;
        string chatRoomId;
        ObservableCollection<Chat> chatList;
        List<Chat> completeList;

        public ChatPage(object userVM, string chatRoomId)
        {
            InitializeComponent();

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Transparent;

            Lbl_chatRoomId.Text = chatRoomId;

            this.chatRoomId = chatRoomId;
            FatchAndBindData();
        }

        private async void FatchAndBindData()
        {
            firebaseHelper = new FirebaseHelper();
            chatList = new ObservableCollection<Chat>();
            completeList = new List<Chat>();

            completeList = await firebaseHelper.GetCompleteChat(chatRoomId);

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
            string message = string.Empty;

            if (!string.IsNullOrWhiteSpace(txt_msg.Text))
            {
                message = txt_msg.Text;
                txt_msg.Text = string.Empty;

                Chat chat = new Chat()
                {
                    Message = message,
                    DateSent = DateTime.Now,
                    Role = 1,
                    Status = 2
                };

                await firebaseHelper.AddChat(chat, chatRoomId);
            }
            else
            {
                await DisplayAlert("Error", "Can't send empty message", "OK");
            }
        }

        public void subChat()
        {
            firebaseHelper.firebase
                .Child("Chats")
                .Child(chatRoomId)
                .OrderByKey()
                .LimitToLast(1)
                .AsObservable<Chat>()
                .Subscribe(d => AddToList(d.Object, d.Key));
        }

        private void AddToList(Chat chat, string key)
        {
            try
            {
                if (chat != null && !(chatList.Count > 0 && chatList.LastOrDefault().DateSent.Ticks.Equals(chat.DateSent.Ticks)))
                {
                    chatList.Add(chat);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}