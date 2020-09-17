using Microsoft.AspNetCore.Mvc;
using MyChefApi.Services;
using MyChefAppModels;
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
        public Response RegisterUser(User user)
        {
            return identityServices.RegisterUser(user);
        }

        [HttpPost]
        public Response UpdateUser(User user)
        {
            return identityServices.UpdateUser(user);
        }

        [HttpGet]
        public Response GetUserByCredentials(User user)
        {
            return identityServices.GetUserByCredentials(user);
        }
    }
}
