using MyChefApp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MyChefApp.Services
{
    public class HttpRequests
    {
        private HttpClientService httpClient;

        public HttpRequests()
        {
            httpClient = new HttpClientService();
        }

        public async Task<Response> RegisterUser(UserVM registrationModel)
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

        public async Task<Response> GetUserByCredentials(UserVM signIn)
        {
            Response response;

            try
            {
                response = JsonConvert.DeserializeObject<Response>(
                    await httpClient.PostAsync($"{ApiRoutes.Base.BaseUrl}{ApiRoutes.MyChefAPI.GetUserByCredentials}", signIn)
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

        public async Task<Response> UpdateUser(UserVM registrationModel)
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

        public async Task<Response> GetFoodList()
        {
            Response response;

            try
            {
                response = JsonConvert.DeserializeObject<Response>(
                    await httpClient.GetAsync($"{ApiRoutes.Base.BaseUrl}{ApiRoutes.MyChefAPI.GetFoodList}")
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
