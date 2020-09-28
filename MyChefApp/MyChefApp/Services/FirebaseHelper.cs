using Firebase.Database;
using Firebase.Database.Query;
using MyChefApp.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MyChefApp.Services
{
    class FirebaseHelper
    {
        public FirebaseClient firebase = new FirebaseClient("https://mychef-app-c0406.firebaseio.com/");

        public ObservableCollection<Chat> chatList;

        //public FirebaseHelper()
        //{
        //    people = new ObservableCollection<Person>();

        //    subChat();
        //}

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
                  Status = item.Object.Status

              }).ToList();
        }

        public async Task AddChat(Chat chat, string chatRoom)
        {
            await firebase
              .Child("Chats")
              .Child(chatRoom)
              .PostAsync(chat);
        }

        //public async Task<Person> GetPerson(int personId)
        //{
        //    var allPersons = await GetAllPersons();
        //    await firebase
        //      .Child("Persons")
        //      .OnceAsync<Person>();
        //    return allPersons.Where(a => a.PersonId == personId).FirstOrDefault();
        //}

        //public async Task UpdatePerson(int personId, string name)
        //{
        //    var toUpdatePerson = (await firebase
        //      .Child("Persons")
        //      .OnceAsync<Person>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();

        //    await firebase
        //      .Child("Persons")
        //      .Child(toUpdatePerson.Key)
        //      .PutAsync(new Person() { PersonId = personId, Name = name });
        //}

        //public async Task DeletePerson(int personId)
        //{
        //    var toDeletePerson = (await firebase
        //      .Child("Persons")
        //      .OnceAsync<Person>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();
        //    await firebase.Child("Persons").Child(toDeletePerson.Key).DeleteAsync();

        //}

        //public async Task saveMessage(Person _ch, string _room)
        //{
        //    await firebase
        //        .Child("Chats")
        //        .Child("Chat")
        //        .PostAsync(_ch);
        //}

        public ObservableCollection<Chat> subChat(string chatRoom)
        {
            //(await firebase
            //  .Child("Persons")
            //  .OnceAsync<Person>()).Select(item => new Person
            //  {
            //      Name = item.Object.Name,
            //      PersonId = item.Object.PersonId
            //  }).ToList();
            ObservableCollection<Chat> list = new ObservableCollection<Chat>();

            list = firebase
                .Child("Chats")
                .Child(chatRoom)
                .OrderByKey()
                .LimitToLast(1)
                .AsObservable<Chat>()
                .AsObservableCollection();

            return list;

            //var observable = firebase
            //  .Child("Persons")
            //  .AsObservable<Person>()
            //  .Subscribe(d => addNewChat(d.Object));
        }

        //private void addNewChat(Person person)
        //{
        //    if (person != null)
        //    {
        //        //await Xamarin.Forms.Page.DisplayAlert("Success", "Person Added Successfully", "OK");
        //        people.Add(person);
        //    }
        //}

    }
}
