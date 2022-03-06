using Firebase.Database;
using Firebase.Database.Query;
using MyChefApp.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MyChefApp.Services
{
    public class FirebaseHelper
    {
        public FirebaseClient firebase = new FirebaseClient("https://mychef-app-c0406.firebaseio.com/");

        public async Task<List<Chat>> GetCompleteChat(string chatRoom)
        {
            return (await firebase
              .Child("Chats")
              .Child(chatRoom)
              .OrderByKey()
              .LimitToLast(200)
              .OnceAsync<Chat>()).Select(item => new Chat
              {
                  Role = item.Object.Role,
                  DateSent = item.Object.DateSent,
                  Message = item.Object.Message,
                  Status = item.Object.Status,
                  UserName = item.Object.UserName

              }).ToList();
        }

        public async Task AddChat(Chat chat, string chatRoom)
        {
            await firebase
              .Child("Chats")
              .Child(chatRoom)
              .PostAsync(chat);
        }
    }
}
