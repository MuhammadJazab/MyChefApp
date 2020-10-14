using MyChefApp.ViewModels;
using MyChefApp.Views;
using Newtonsoft.Json;
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

        public static void RemoveSession()
        {
            SecureStorage.RemoveAll();
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
                            App.UserId = user.UserId;

                            if (user.CookingSkillId > 0)
                            {
                                if (user.HasFoodPreference)
                                {
                                    App.Current.MainPage = new NavigationPage(new WeeklyMenu(user));
                                }
                                else
                                {
                                    App.Current.MainPage = new NavigationPage(new MyDiet(user));
                                }
                            }
                            else
                            {
                                App.Current.MainPage = new NavigationPage(new Skills(user));
                            }
                        }
                        else
                        {
                            App.Current.MainPage = new NavigationPage(new Account(user));
                        }
                    }
                    else
                    {
                        App.Current.MainPage = new NavigationPage(new Login());
                    }
                }
            }
            else
            {
                App.Current.MainPage = new NavigationPage(new Login());
            }
        }
    }
}
