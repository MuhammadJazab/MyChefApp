using Microsoft.Extensions.Configuration;
using MyChefApi.Helpers;
using MyChefApp.ViewModels;
using MyChefAppModels;
using MyChefAppViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        Task<Response> AddMenuItem(MenuItemVM menuItemVM);
        Task<List<MenuItemVM>> GetMenuItem();
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
               // string eStr = CustomCryptography.PasswordEncrypt(_user.Password, configuration.GetValue<string>("EncryptionKey"));

                User user = uow.Repository<User>().Get().Where(x => x.Email == _user.Email && x.Password == _user.Password && x.IsAdmin == true).FirstOrDefault();

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

        public async Task<Response> AddMenuItem(MenuItemVM menuItemVM)
        {
            try
            {
                Response response = new Response();
                if (menuItemVM.MenuId>0 && menuItemVM.MenuRecipeId>0)
                {
                    WeekMenu weekMenu = new WeekMenu();
                    weekMenu=  uow.Repository<WeekMenu>().Get(x=>x.MenuId==menuItemVM.MenuId).FirstOrDefault();
                    weekMenu.WeekDay = menuItemVM.Day;
                    weekMenu.MenuTitle = menuItemVM.Title;
                    uow.Repository<WeekMenu>().Update(weekMenu);
                    await uow.SaveAsync();

                    Recipes recipes = new Recipes();
                    recipes = uow.Repository<Recipes>().Get(x=>x.MenuRecipeId==menuItemVM.MenuRecipeId).FirstOrDefault();
                    recipes.Directions = menuItemVM.Direction;
                    recipes.MenuDay = menuItemVM.Day;
                    uow.Repository<Recipes>().Update(recipes);
                    await uow.SaveAsync();
                }
                else
                {
                    WeekMenu menu = new WeekMenu()
                    {
                        MenuTitle = menuItemVM.Title,
                        WeekDay = menuItemVM.Day,
                        IsEven = false
                    };
                    await uow.Repository<WeekMenu>().AddAsync(menu);
                    await uow.SaveAsync();
                    Recipes recipes = new Recipes()
                    {
                        MenuDay = menuItemVM.Day,
                        Directions = menuItemVM.Direction,
                        MenuId = menu.MenuId
                    };

                    await uow.Repository<Recipes>().AddAsync(recipes);
                    await uow.SaveAsync();

                    foreach (var item in menuItemVM.InGridient)
                    {
                        Ingredients ingredients = new Ingredients()
                        {
                            MenuRecipeId = recipes.MenuRecipeId,
                            MenuIngredients = item
                        };
                        await uow.Repository<Ingredients>().AddAsync(ingredients);

                    }
                    await uow.SaveAsync();
                    response.Status = ResponseStatus.OK;
                    response.Message = "Successfully Inserted";
                }
                return response;


            }
            catch (Exception ex)
            {
                return new Response();
            }
        }

        public async Task<List<MenuItemVM>> GetMenuItem()
        {
            List<MenuItemVM> menuItemVMs = new List<MenuItemVM>();
            List<Recipes> recipes = new List<Recipes>();
            List<WeekMenu> weekMenu = new List<WeekMenu>();
            List<Ingredients> ingredients = new List<Ingredients>();
            List<long> menuId = new List<long>();
            List<long> menuRecipeId = new List<long>();

            weekMenu = uow.Repository<WeekMenu>().Get().ToList();
            menuId = weekMenu.Select(x => x.MenuId).ToList();
            recipes = uow.Repository<Recipes>().Get(x => menuId.Contains(x.MenuId)).ToList();
            menuRecipeId = recipes.Select(x => x.MenuRecipeId).ToList();
            ingredients = uow.Repository<Ingredients>().Get(x => menuRecipeId.Contains(x.MenuRecipeId)).ToList();

            menuItemVMs = weekMenu.Select(y => new MenuItemVM
            {
                MenuId=y.MenuId,
                MenuRecipeId= recipes.FirstOrDefault(x => x.MenuId == y.MenuId).MenuRecipeId,
                Day = y.WeekDay,
                Title = y.MenuTitle,
                Direction = recipes.FirstOrDefault(x => x.MenuId == y.MenuId).Directions,
                InGridient = ingredients.Where(x => recipes.Where(w => w.MenuId == y.MenuId).Select(s => s.MenuRecipeId).ToList().Contains(x.MenuRecipeId)).Select(o => o.MenuIngredients
                ).ToList()
            }).ToList();





            return menuItemVMs;

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
