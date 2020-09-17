using MyChefApp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MyChefApp.Services
{
    public class AuthServices
    {
        private HttpClientService httpClient;

        public AuthServices()
        {
            httpClient = new HttpClientService();
        }

        public async Task<Response> RegisterUser(RegistrationVM registrationModel)
        {
            Response response;

            try
            {
                response = JsonConvert.DeserializeObject<Response>(
                    await httpClient.PostAsync($"{ApiRoutes.Base.BaseUrl}{ApiRoutes.MyChefAPI.RegisterUser}", registrationModel)
                );
            }
            catch (Exception ex)
            {
                response = new Response()
                {
                    Status = ResponseStatus.Error,
                    Message = ex.Message,
                    ResultData = null
                };
            }

            return response;
        }

        public async Task<Response> GetUserByCredentials(SignIn signIn)
        {
            Response response;

            try
            {
                response = JsonConvert.DeserializeObject<Response>(
                    await httpClient.PostAsync($"{ApiRoutes.Base.BaseUrl}{ApiRoutes.MyChefAPI.GetUserByCredentials}", new RegistrationVM() { Email = signIn.Email, Password = signIn.Password })
                );
            }
            catch (Exception ex)
            {
                response = new Response()
                {
                    Status = ResponseStatus.Error,
                    Message = ex.Message,
                    ResultData = null
                };
            }

            return response;
        }

        private async Task<Response> UpdateUser(RegistrationVM registrationModel)
        {
            Response response;

            try
            {
                response = JsonConvert.DeserializeObject<Response>(
                    await httpClient.PostAsync($"{ApiRoutes.Base.BaseUrl}{ApiRoutes.MyChefAPI.UpdateUser}", registrationModel)
                );
            }
            catch (Exception ex)
            {
                response = new Response()
                {
                    Status = ResponseStatus.Error,
                    Message = ex.Message,
                    ResultData = null
                };
            }

            return response;
        }

    }
}
