using MyChefApp.ViewModels;
using MyChefApp.Views;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyChefApp.Services
{
    public static class SessionManagement
    {
        public static async Task SetSession(string key, string value)
        {
            await SecureStorage.SetAsync(key, value);
        }

        public static string GetSession(string key)
        {
            return SecureStorage.GetAsync(key).Result;
        }

        public static bool RemoveSession(string key)
        {
            return SecureStorage.Remove(key);
        }

        public static void LoginMechanism()
        {
            string userJson = GetSession(SessionKey.Token);

            if (!string.IsNullOrEmpty(userJson))
            {
                UserVM user = JsonConvert.DeserializeObject<UserVM>(userJson);

                if (user != null)
                {
                    if (!string.IsNullOrEmpty(user.Email))
                    {
                        if (user.AccountTypeId > 0)
                        {
                            if (user.CookingSkillId > 0)
                            {
                                if (user.UserFoodPreferences!=null && user.UserFoodPreferences.Count > 0)
                                {
                                    App.User = $"{user.UserName}_{user.UserId}";
                                    App.Current.MainPage = new NavigationPage(new ChatPage("chat_123"));
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                App.Current.MainPage = new NavigationPage(new ChatPage("chat_123"));
            }
        }
    }
}
