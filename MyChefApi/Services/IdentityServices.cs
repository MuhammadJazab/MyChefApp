using Microsoft.Extensions.Configuration;
using MyChefApi.Helpers;
using MyChefApp.ViewModels;
using MyChefAppModels;
using MyChefAppViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities;

namespace MyChefApi.Services
{
    public interface IIdentityServices
    {
        Task<Response> RegisterUser(UserVM _user);
        Response UpdateUser(UserVM _user);
        Response GetUserByCredentials(UserVM _user);
        Response GetFoodList();
        Response GetCookingSkills();
        Response GetWeeklyMenu();
        Response GetRecipeByMenuId(long menuId);
        Response GetUserGoalsByUserId(long userId);
        Response GetUserProfileImageByUserId(long userId);
        Task<Response> SetUserGoalsByUserId(GoalsVM goalsVM);
        Response UpdateGoalByGoalId(long automationId, bool? isChecked);
        Response GetFoodGallery();
    }

    public class IdentityServices : IIdentityServices
    {
        private readonly IUnitOfWork uow;
        private readonly IConfiguration configuration;

        public IdentityServices(IUnitOfWork uow, IConfiguration configuration)
        {
            this.uow = uow;
            this.configuration = configuration;
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

        public Response GetRecipeByMenuId(long menuId)
        {
            Response response;

            try
            {
                Recipes recipe = uow.Repository<Recipes>().Get().Where(x => x.MenuId == menuId).FirstOrDefault();
                WeekMenu weekMenu = uow.Repository<WeekMenu>().Get(x => x.MenuId == menuId).FirstOrDefault();
                List<Ingredients> ingredients = uow.Repository<Ingredients>().Get().Where(x => x.MenuRecipeId == recipe.MenuRecipeId).ToList();

                RecipeVM recipeVM = new RecipeVM()
                {
                    Directions = recipe.Directions,
                    MenuDay = recipe.MenuDay,
                    MenuId = recipe.MenuId,
                    MenuRecipeId = recipe.MenuRecipeId,
                    MenuTitle = weekMenu.MenuTitle,
                    RecipeIngredients = ingredients.Select(x => new IngredientsVM()
                    {
                        IngredientId = x.IngredientId,
                        MenuIngredients = x.MenuIngredients,
                        MenuRecipeId = x.MenuRecipeId
                    }).ToList()
                };

                if (recipe != null)
                {
                    response = new Response()
                    {
                        Message = "Login Successfully",
                        ResultData = recipeVM,
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

        public Response GetUserByCredentials(UserVM _user)
        {
            Response response;

            try
            {
                string eStr = CustomCryptography.PasswordEncrypt(_user.Password, configuration.GetValue<string>("EncryptionKey"));

                User user = uow.Repository<User>().Get().Where(x => x.Email == _user.Email && x.Password == eStr && _user.IsAdmin == x.IsAdmin).FirstOrDefault();

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

        public async Task<Response> RegisterUser(UserVM _user)
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
                        UserName = _user.UserName,
                        IsAdmin = _user.IsAdmin
                    };

                    uow.Repository<User>().Add(userDTO);

                    await uow.SaveAsync();

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
                    ResultData = ex,
                    Status = ResponseStatus.Error
                };
            }

            return response;
        }

        public Response GetUserGoalsByUserId(long userId)
        {
            Response response;

            try
            {
                List<Goals> goals = uow.Repository<Goals>().Get().Where(x => x.UserId == userId).ToList();

                if (goals.Count > 0)
                {
                    response = new Response()
                    {
                        Message = "Goals found successfully",
                        ResultData = goals,
                        Status = ResponseStatus.OK
                    };
                }
                else
                {
                    response = new Response()
                    {
                        Message = "Goals not found",
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

        public async Task<Response> SetUserGoalsByUserId(GoalsVM goalsVM)
        {
            Response response;

            try
            {
                Goals isGoalExist = uow.Repository<Goals>().Get(x => x.GoalId == goalsVM.GoalId).FirstOrDefault();

                if (isGoalExist == null)
                {
                    int goalCount = uow.Repository<Goals>().GetAll().Where(x => x.UserId == goalsVM.UserId).Count();

                    if (goalCount <= 4)
                    {
                        Goals goals = new Goals()
                        {
                            UserId = goalsVM.UserId,
                            GoalCompleted = goalsVM.GoalCompleted,
                            GoalText = goalsVM.GoalText
                        };

                        uow.Repository<Goals>().Add(goals);

                        await uow.SaveAsync();

                        response = new Response()
                        {
                            Message = "Goal Saved Successfully",
                            ResultData = goals,
                            Status = ResponseStatus.OK
                        };
                    }
                    else
                    {
                        response = new Response()
                        {
                            Message = "Goal limit reached, you are allowed to add 4 goals",
                            ResultData = goalCount,
                            Status = ResponseStatus.Restrected
                        };
                    }
                }
                else
                {
                    Goals goals = new Goals()
                    {
                        UserId = goalsVM.UserId,
                        GoalCompleted = goalsVM.GoalCompleted,
                        GoalText = goalsVM.GoalText,
                        GoalId = goalsVM.GoalId
                    };

                    uow.Repository<Goals>().Update(goals);

                    await uow.SaveAsync();

                    response = new Response()
                    {
                        Message = "Goal update Successfully",
                        ResultData = goals,
                        Status = ResponseStatus.OK
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

        public Response GetUserProfileImageByUserId(long userId)
        {
            Response response;

            try
            {
                byte[] userProfileImage = uow.Repository<User>().Get().Where(x => x.UserId == userId).FirstOrDefault().ProfileImage;

                if (userProfileImage?.Length > 0)
                {
                    response = new Response()
                    {
                        Message = "",
                        ResultData = JsonConvert.SerializeObject(userProfileImage),
                        Status = ResponseStatus.OK
                    };
                }
                else
                {
                    response = new Response()
                    {
                        Message = "No Image found",
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

        public Response UpdateUser(UserVM _user)
        {
            Response response;

            try
            {
                User user = uow.Repository<User>().Get(x => x.Email == _user.Email).FirstOrDefault();

                if (user != null)
                {
                    if (_user?.UserFoodPreferences?.Count > 0)
                    {
                        foreach (var food in _user?.UserFoodPreferences)
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
                    user.ProfileImage = _user?.ProfileImage;

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

        public Response UpdateGoalByGoalId(long automationId, bool? isChecked)
        {
            Response response;

            try
            {
                Goals goals = uow.Repository<Goals>().Get().Where(x => x.GoalId == automationId).FirstOrDefault();

                if (goals != null)
                {
                    goals.GoalCompleted = isChecked.Value;

                    uow.Repository<Goals>().Update(goals);
                    uow.SaveAsync();

                    response = new Response()
                    {
                        Message = "Goals Updated successfully",
                        ResultData = goals,
                        Status = ResponseStatus.OK
                    };
                }
                else
                {
                    response = new Response()
                    {
                        Message = "Goals not found",
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

        public Response GetFoodGallery()
        {
            Response response;

            try
            {
                List<FoodGallery> foods = uow.Repository<FoodGallery>().GetAll().ToList();

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
                        Message = "No images found.",
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
    }
}