using Microsoft.Extensions.Configuration;
using MyChefApp.ViewModels;
using MyChefAppModels;
using MyChefAppViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
                string eStr = PasswordEncrypt(_user.Password, configuration.GetValue<string>("EncryptionKey"));

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
                    string eStr = PasswordEncrypt(_user.Password, configuration.GetValue<string>("EncryptionKey"));

                    User userDTO = new User()
                    {
                        AccountTypeId = _user.AccountTypeId,
                        CookingSkillId = _user.CookingSkillId,
                        Email = _user.Email,
                        Password = eStr,
                        UserName = _user.UserName
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

        public string PasswordEncrypt(string inText, string key)
        {
            byte[] bytesBuff = Encoding.Unicode.GetBytes(inText);
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = crypto.GetBytes(32);
                aes.IV = crypto.GetBytes(16);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytesBuff, 0, bytesBuff.Length);
                        cStream.Close();
                    }
                    inText = Convert.ToBase64String(mStream.ToArray());
                }
            }
            return inText;
        }

        //Decrypting a string
        public string PasswordDecrypt(string cryptTxt, string key)
        {
            cryptTxt = cryptTxt.Replace(" ", "+");
            byte[] bytesBuff = Convert.FromBase64String(cryptTxt);
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = crypto.GetBytes(32);
                aes.IV = crypto.GetBytes(16);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytesBuff, 0, bytesBuff.Length);
                        cStream.Close();
                    }
                    cryptTxt = Encoding.Unicode.GetString(mStream.ToArray());
                }
            }
            return cryptTxt;
        }
    }
}