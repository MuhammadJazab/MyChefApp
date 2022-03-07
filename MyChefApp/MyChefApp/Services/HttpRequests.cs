using MyChefApp.ViewModels;
using MyChefAppViewModels;
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

        internal async Task<Response> GetFoodGallery()
        {
            Response response;

            try
            {
                response = JsonConvert.DeserializeObject<Response>(
                    await httpClient.GetAsync($"{ApiRoutes.Base.BaseUrl}{ApiRoutes.MyChefAPI.GetFoodGallery}")
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

        public async Task<Response> GetUserProfileImageByUserId(long userId)
        {
            Response response;

            try
            {
                response = JsonConvert.DeserializeObject<Response>(
                    await httpClient.GetAsync($"{ApiRoutes.Base.BaseUrl}{ApiRoutes.MyChefAPI.GetUserProfileImageByUserId}?userId={userId}")
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

        public async Task<Response> GetUserGoalsByUserId(long userId)
        {
            Response response;

            try
            {
                response = JsonConvert.DeserializeObject<Response>(
                    await httpClient.GetAsync($"{ApiRoutes.Base.BaseUrl}{ApiRoutes.MyChefAPI.GetUserGoalsByUserId}?userId={userId}")
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

        public async Task<Response> GetRecipeByMenuId(long menuId)
        {
            Response response;

            try
            {
                response = JsonConvert.DeserializeObject<Response>(
                    await httpClient.GetAsync($"{ApiRoutes.Base.BaseUrl}{ApiRoutes.MyChefAPI.GetRecipeByMenuId}?menuId={menuId}")
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

        public async Task<Response> GetCookingSkills()
        {
            Response response;

            try
            {
                response = JsonConvert.DeserializeObject<Response>(
                    await httpClient.GetAsync($"{ApiRoutes.Base.BaseUrl}{ApiRoutes.MyChefAPI.GetCookingSkills}")
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

        internal async Task<Response> UploadFoodImage(FoodGalleryVM foodGalleryVM)
        {
            Response response;

            try
            {
                response = JsonConvert.DeserializeObject<Response>(
                    await httpClient.PostAsync($"{ApiRoutes.Base.BaseUrl}{ApiRoutes.MyChefAPI.UploadFoodImage}", foodGalleryVM)
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

        public async Task<Response> GetWeeklyMenu()
        {
            Response response;

            try
            {
                response = JsonConvert.DeserializeObject<Response>(
                    await httpClient.GetAsync($"{ApiRoutes.Base.BaseUrl}{ApiRoutes.MyChefAPI.GetWeeklyMenu}")
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

        public async Task<Response> UpdateGoalByGoalId(long automationId, bool? isChecked)
        {
            Response response;

            try
            {
                response = JsonConvert.DeserializeObject<Response>(
                    await httpClient.GetAsync($"{ApiRoutes.Base.BaseUrl}{ApiRoutes.MyChefAPI.UpdateGoalByGoalId}?automationId={automationId}&isChecked={isChecked}")
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

        public async Task<Response> SetUserGoalsByUserId(GoalsVM goalsVM)
        {
            Response response;

            try
            {
                response = JsonConvert.DeserializeObject<Response>(
                    await httpClient.PostAsync($"{ApiRoutes.Base.BaseUrl}{ApiRoutes.MyChefAPI.SetUserGoalsByUserId}", goalsVM)
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
