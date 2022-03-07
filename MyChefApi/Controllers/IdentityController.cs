using Microsoft.AspNetCore.Mvc;
using MyChefApi.Services;
using MyChefApp.ViewModels;
using MyChefAppModels;
using MyChefAppViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities;

namespace MyChefApi.Controllers
{
    [Produces("Application/json")]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityServices identityServices;

        public IdentityController(IIdentityServices identityServices)
        {
            this.identityServices = identityServices;
        }

        [HttpGet]
        public string Start()
        {
            return "Server Start Successfully";
        }

        [HttpPost]
        public async Task<Response> RegisterUser([FromBody] UserVM user)
        {
            return await identityServices.RegisterUser(user);
        }

        [HttpPost]
        public Response UpdateUser([FromBody] UserVM user)
        {
            return identityServices.UpdateUser(user);
        }

        [HttpPost]
        public Response GetUserByCredentials([FromBody] UserVM user)
        {
            return identityServices.GetUserByCredentials(user);
        }

        [HttpGet]
        public Response GetFoodList()
        {
            return identityServices.GetFoodList();
        }

        [HttpGet]
        public Response GetFoodGallery()
        {
            return identityServices.GetFoodGallery();
        }

        [HttpGet]
        public Response GetCookingSkills()
        {
            return identityServices.GetCookingSkills();
        }

        [HttpGet]
        public Response GetWeeklyMenu()
        {
            return identityServices.GetWeeklyMenu();
        }

        [HttpGet]
        public Response GetRecipeByMenuId(long menuId)
        {
            return identityServices.GetRecipeByMenuId(menuId);
        }

        [HttpGet]
        public Response GetUserGoalsByUserId(long userId)
        {
            return identityServices.GetUserGoalsByUserId(userId);
        }

        [HttpGet]
        public Response UpdateGoalByGoalId(long automationId, bool? isChecked)
        {
            return identityServices.UpdateGoalByGoalId(automationId, isChecked);
        }

        [HttpPost]
        public async Task<Response> UploadFoodImage([FromBody] FoodGalleryVM foodGalleryVM)
        {
            return await identityServices.UploadFoodImage(foodGalleryVM);
        }

        [HttpPost]
        public async Task<Response> SetUserGoalsByUserId([FromBody] GoalsVM goalsVM)
        {
            return await identityServices.SetUserGoalsByUserId(goalsVM);
        }

        [HttpGet]
        public Response GetUserProfileImageByUserId(long userId)
        {
            return identityServices.GetUserProfileImageByUserId(userId);
        }
    }
}
