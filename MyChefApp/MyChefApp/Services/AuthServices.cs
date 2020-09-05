using Firebase.Database.Query;
using MyChefApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyChefApp.Services
{
    public class AuthServices
    {
        public async Task<Response> RegisterUser(RegistrationModel registrationModel)
        {
            Response response;

            try
            {
                string registrationJson = JsonConvert.SerializeObject(registrationModel);

                var firebaseObject = await App.firebaseClient.Child(TableName.UserTable).PostAsync(registrationJson);
                await UpdateUser(registrationModel);

                response = new Response()
                {
                    Status = ResponseStatus.OK,
                    ResultData = firebaseObject.Key
                };
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

        public async Task<Response> SignIn(SignIn signIn)
        {
            Response response;

            try
            {
                List<RegistrationModel> allUsers = (List<RegistrationModel>)(await GetAllUsers()).ResultData;

                var user = allUsers.Where(x => x.Email == signIn.Email && x.Password == signIn.Password).FirstOrDefault();

                if (user != null)
                {
                    response = new Response()
                    {
                        ResultData = user.UserId,
                        Status = ResponseStatus.OK,
                        Message = Messages.LoginSuccessfully
                    };
                }
                else
                {
                    response = new Response()
                    {
                        ResultData = user,
                        Message = Messages.InvalidUsers,
                        Status = ResponseStatus.Restrected
                    };
                }
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

        private async Task<Response> UpdateUser(RegistrationModel registrationModel)
        {
            Response response;

            try
            {
                var user = (await App.firebaseClient.Child(TableName.UserTable).OnceAsync<RegistrationModel>())
                    .Where(x => x.Object.Email == registrationModel.Email && x.Object.Password == registrationModel.Password)
                    .FirstOrDefault();

                if (user != null)
                {
                    var regModel = new RegistrationModel
                    {
                        UserId = user.Key,
                        Email = registrationModel.Email,
                        Password = registrationModel.Password,
                        UserName = registrationModel.UserName
                    };

                    await App.firebaseClient
                        .Child(TableName.UserTable)
                        .Child(user.Key)
                        .PutAsync(JsonConvert.SerializeObject(regModel));

                    response = new Response()
                    {
                        Status = ResponseStatus.OK,
                        Message = "",
                        ResultData = true
                    };
                }
                else
                {
                    response = new Response()
                    {
                        Status = ResponseStatus.Restrected,
                        Message = Messages.UserNotExist,
                        ResultData = true
                    };
                }
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

        public async Task<Response> GetAllUsers()
        {
            Response response;

            try
            {
                List<RegistrationModel> userList = (await App.firebaseClient.Child(TableName.UserTable).OnceAsync<RegistrationModel>())
                    .Select(x => new RegistrationModel
                    {
                        UserId = x.Key,
                        Email = x.Object.Email,
                        Password = x.Object.Password,
                        UserName = x.Object.UserName
                    }).ToList();

                response = new Response()
                {
                    Status = ResponseStatus.OK,
                    ResultData = userList
                };
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
