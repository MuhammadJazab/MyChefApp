using MyChefApp.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MyChefApp.Services
{
    public class AuthServices
    {
        public async Task<Response> RegisterUser(RegistrationModel registrationModel)
        {
            //Response response;

            string registrationJson = JsonConvert.SerializeObject(registrationModel);
            var aa = await App.firebaseClient.Child("Users").PostAsync(registrationJson);

            return new Response() ;
        }

        //public async Task<Response> SignIn(SignIn signIn)
        //{
        //    Response response;


        //    return response;
        //}
    }
}
