using Microsoft.AspNetCore.Mvc;
using MyChefApi.Services;
using MyChefApp.ViewModels;
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
        public Response RegisterUser([FromBody] UserVM user)
        {
            return identityServices.RegisterUser(user);
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
    }
}
