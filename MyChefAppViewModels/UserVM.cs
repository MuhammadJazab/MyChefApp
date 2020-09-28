using System;
using System.Collections.Generic;
using System.Text;

namespace MyChefApp.ViewModels
{
    public class UserVM
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public long AccountTypeId { get; set; }
        public long CookingSkillId { get; set; }
        public List<FoodVM> UserFoodPreferences { get; set; }
    }
}
