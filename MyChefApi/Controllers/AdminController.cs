using Microsoft.AspNetCore.Mvc;
using MyChefApi.Services;
using MyChefApp.ViewModels;
using MyChefAppViewModels;
using System.Threading.Tasks;
using Utilities;

namespace MyChefApi.Controllers
{
    [Produces("Application/json")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices adminServices;

        public AdminController(IAdminServices adminServices)
        {
            this.adminServices = adminServices;
        }

        [HttpGet]
        public Response GetMenuList()
        {
            return adminServices.GetMenuList();
        }

        [HttpGet]
        public Response GetUsersList()
        {
            return adminServices.GetUsersList();
        }

        [HttpPost]
        public Response RegisterNewAdmin([FromBody] UserVM user)
        {
            return adminServices.RegisterNewAdmin(user);
        }

        [HttpPost]
        public Response LoginAdmin([FromBody] UserVM user)
        {
            return adminServices.LoginAdmin(user);
        }

        [HttpGet]
        public Response RemoveUserByUserID(long userId)
        {
            return adminServices.RemoveUserByUserID(userId);
        }
        [HttpPost]
        public Task<Response> AddMenuItem([FromBody] MenuItemVM menuItemVM)
        {

            return adminServices.AddMenuItem(menuItemVM);
        }
    }
}
