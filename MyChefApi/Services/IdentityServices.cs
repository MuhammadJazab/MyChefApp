using MyChefApp.ViewModels;
using MyChefAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities;

namespace MyChefApi.Services
{
    public interface IIdentityServices
    {
        Response RegisterUser(UserVM _user);
        Response UpdateUser(UserVM _user);
        Response GetUserByCredentials(UserVM _user);
        Response GetFoodList();
        Response GetCookingSkills();
        Response GetWeeklyMenu();
    }

    public class IdentityServices : IIdentityServices
    {
        private readonly IUnitOfWork uow;

        public IdentityServices(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public Response GetCookingSkills()
        {
            Response response;

            try
            {
                List<CookingSkills> cookingSkills = uow.Repository<CookingSkills>().GetAll().ToList();

                if (cookingSkills != null)
                {
                    response = new Response()
                    {
                        Message = "Successfully fetch cooking skills",
                        ResultData = cookingSkills,
                        Status = ResponseStatus.OK
                    };
                }
                else
                {
                    response = new Response()
                    {
                        Message = "failed to fetch cooking skills",
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

        public Response GetFoodList()
        {
            Response response;

            try
            {
                List<Foods> foods = uow.Repository<Foods>().GetAll().ToList();

                if (foods != null)
                {
                    response = new Response()
                    {
                        Message = "",
                        ResultData = foods,
                        Status = ResponseStatus.OK
                    };
                }
                else
                {
                    response = new Response()
                    {
                        Message = "",
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

        public Response GetUserByCredentials(UserVM _user)
        {
            Response response;

            try
            {
                User user = uow.Repository<User>().Get().Where(x => x.Email == _user.Email && x.Password == _user.Password).FirstOrDefault();

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

        public Response GetWeeklyMenu()
        {
            Response response;

            try
            {
                List<WeekMenu> weekMenu = uow.Repository<WeekMenu>().GetAll().ToList();

                if (weekMenu != null)
                {
                    response = new Response()
                    {
                        Message = "",
                        ResultData = weekMenu,
                        Status = ResponseStatus.OK
                    };
                }
                else
                {
                    response = new Response()
                    {
                        Message = "",
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

        public Response RegisterUser(UserVM _user)
        {
            Response response;

            try
            {
                uow.Repository<User>().Add(new User() 
                {
                    AccountTypeId = _user.AccountTypeId,
                    CookingSkillId = _user.CookingSkillId,
                    Email = _user.Email,
                    Password = _user.Password,
                    UserId = _user.UserId,
                    UserName = _user.UserName
                });

                uow.Save();

                response = new Response()
                {
                    Message = "User Saved Successfully",
                    ResultData = _user,
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

        public Response UpdateUser(UserVM _user)
        {
            Response response;

            try
            {
                User user = uow.Repository<User>().Get(x => x.Email == _user.Email).FirstOrDefault();

                if (user != null)
                {
                    if (_user.UserFoodPreferences.Count > 0)
                    {
                        foreach (var food in _user.UserFoodPreferences)
                        {
                            uow.Repository<FoodPreferences>().Add(new FoodPreferences()
                            {
                                FoodId = food.FoodId,
                                UserId = _user.UserId
                            });
                        }

                        user.HasFoodPreference = true;
                    }

                    user.AccountTypeId = _user.AccountTypeId;
                    user.CookingSkillId = _user.CookingSkillId;
                    user.Email = _user.Email;
                    user.Password = _user.Password;
                    user.UserName = _user.UserName;

                    uow.Repository<User>().Update(user);

                    uow.Save();

                    response = new Response()
                    {
                        Message = "User Saved Successfully",
                        ResultData = _user,
                        Status = ResponseStatus.OK
                    };
                }
                else
                {
                    response = new Response()
                    {
                        Message = "User Not Found",
                        ResultData = null,
                        Status = ResponseStatus.Error
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
    }
}