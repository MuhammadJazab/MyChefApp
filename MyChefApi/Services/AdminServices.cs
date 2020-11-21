using Microsoft.Extensions.Configuration;
using MyChefApi.Helpers;
using MyChefApp.ViewModels;
using MyChefAppModels;
using MyChefAppViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities;

namespace MyChefApi.Services
{
    public interface IAdminServices
    {
        Response GetMenuList();
        Response GetUsersList();
        Response RegisterNewAdmin(UserVM user);
        Response RemoveUserByUserID(long userId);
        Response LoginAdmin(UserVM user);
    }

    public class AdminServices : IAdminServices
    {
        private readonly IUnitOfWork uow;
        private readonly IConfiguration configuration;

        public AdminServices(IUnitOfWork uow, IConfiguration configuration)
        {
            this.uow = uow;
            this.configuration = configuration;
        }

        public Response GetMenuList()
        {
            Response response;

            try
            {
                List<WeekMenu> weekMenus = uow.Repository<WeekMenu>().Get().ToList();

                List<long> weekMenuIds = weekMenus.Select(x => x.MenuId).ToList();

                List<Recipes> recipes = uow.Repository<Recipes>().GetAll().Where(x => weekMenuIds.Contains(x.MenuId)).ToList();

                response = new Response()
                {
                    Message = "User Saved Successfully",
                    ResultData = recipes,
                    Status = ResponseStatus.OK
                };
            }
            catch (Exception ex)
            {
                response = new Response()
                {
                    Message = "Something went wrong, try again",
                    ResultData = ex.Message,
                    Status = ResponseStatus.Error
                };
            }

            return response;
        }

        public Response GetUsersList()
        {
            Response response;

            try
            {
                List<User> user = uow.Repository<User>().GetAll().ToList();

                if (user.Count > 0)
                {
                    response = new Response()
                    {
                        Message = "User Saved Successfully",
                        ResultData = user,
                        Status = ResponseStatus.OK
                    };
                }
                else
                {
                    response = new Response()
                    {
                        Message = "No users found",
                        ResultData = null,
                        Status = ResponseStatus.Restrected
                    };
                }
            }
            catch (Exception ex)
            {
                response = new Response()
                {
                    Message = "Something went wrong, try again",
                    ResultData = ex.Message,
                    Status = ResponseStatus.Error
                };
            }

            return response;
        }

        public Response RegisterNewAdmin(UserVM _user)
        {
            Response response;

            try
            {
                User user = uow.Repository<User>().Get().Where(x => x.Email == _user.Email).FirstOrDefault();

                if (user == null)
                {
                    string eStr = CustomCryptography.PasswordEncrypt(_user.Password, configuration.GetValue<string>("EncryptionKey"));

                    User userDTO = new User()
                    {
                        AccountTypeId = _user.AccountTypeId,
                        CookingSkillId = _user.CookingSkillId,
                        Email = _user.Email,
                        Password = eStr,
                        UserName = _user.UserName
                    };

                    uow.Repository<User>().Add(userDTO);

                    uow.SaveAsync();

                    response = new Response()
                    {
                        Message = "User Saved Successfully",
                        ResultData = userDTO,
                        Status = ResponseStatus.OK
                    };
                }
                else
                {
                    response = new Response()
                    {
                        Message = "Email Already exists",
                        ResultData = null,
                        Status = ResponseStatus.Restrected
                    };
                }
            }
            catch (Exception ex)
            {
                response = new Response()
                {
                    Message = "Something went wrong, try again",
                    ResultData = ex.Message,
                    Status = ResponseStatus.Error
                };
            }

            return response;
        }

        public Response RemoveUserByUserID(long userId)
        {
            Response response;

            try
            {
                User user = uow.Repository<User>().Get().Where(x => x.UserId == userId).FirstOrDefault();

                if (user != null)
                {
                    uow.Repository<User>().Delete(user);

                    response = new Response()
                    {
                        Message = "User Deleted Successfully",
                        ResultData = user,
                        Status = ResponseStatus.OK
                    };
                }
                else
                {
                    response = new Response()
                    {
                        Message = "User Not Found",
                        ResultData = null,
                        Status = ResponseStatus.Restrected
                    };
                }
            }
            catch (Exception ex)
            {
                response = new Response()
                {
                    Message = "Something went wrong, try again",
                    ResultData = ex.Message,
                    Status = ResponseStatus.Error
                };
            }

            return response;
        }

        public Response LoginAdmin(UserVM _user)
        {
            Response response;

            try
            {
                string eStr = CustomCryptography.PasswordEncrypt(_user.Password, configuration.GetValue<string>("EncryptionKey"));

                User user = uow.Repository<User>().Get().Where(x => x.Email == _user.Email && x.Password == eStr).FirstOrDefault();

                if (user != null)
                {
                    response = new Response()
                    {
                        Message = "Login Successfully",
                        ResultData = user,
                        Status = ResponseStatus.OK
                    };
                }
                else
                {
                    response = new Response()
                    {
                        Message = "Invalid Email or Password",
                        ResultData = null,
                        Status = ResponseStatus.Restrected
                    };
                }
            }
            catch (Exception ex)
            {
                response = new Response()
                {
                    Message = "Something went wrong, try again",
                    ResultData = ex.Message,
                    Status = ResponseStatus.Error
                };
            }

            return response;
        }

        //public Response AddUpdateRecipes(RecipeVM recipeVM)
        //{
        //    Response response;

        //    try
        //    {
        //        RecipeVM rexistingRecipe = uow.Repository<RecipeVM>().Get().Where(x => x.MenuRecipeId == recipeVM.MenuRecipeId).FirstOrDefault();

        //        if (rexistingRecipe == null)
        //        {
        //            Recipes recipes = new Recipes()
        //            {

        //            };

        //            uow.Repository<User>().Add(userDTO);

        //            uow.SaveAsync();

        //            response = new Response()
        //            {
        //                Message = "User Saved Successfully",
        //                ResultData = userDTO,
        //                Status = ResponseStatus.OK
        //            };
        //        }
        //        else
        //        {
        //            response = new Response()
        //            {
        //                Message = "Email Already exists",
        //                ResultData = null,
        //                Status = ResponseStatus.Restrected
        //            };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response = new Response()
        //        {
        //            Message = "Something went wrong, try again",
        //            ResultData = ex.Message,
        //            Status = ResponseStatus.Error
        //        };
        //    }

        //    return response;
        //}
    }
}
