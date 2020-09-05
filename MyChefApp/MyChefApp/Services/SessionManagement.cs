using MyChefApp.Models;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MyChefApp.Services
{
    public static class SessionManagement
    {
        public static async Task SetSession(string key,string value)
        {
            await SecureStorage.SetAsync(key, value);
        }

        public static string GetSession(string key)
        {
            return SecureStorage.GetAsync(key).Result;
        }
    }
}
