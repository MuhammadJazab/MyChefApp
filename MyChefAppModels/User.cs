using System;
using System.Collections.Generic;

namespace MyChefAppModels
{
    public partial class User
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public long AccountTypeId { get; set; }
        public long CookingSkillId { get; set; }
        public bool HasFoodPreference { get; set; }
        public byte[] ProfileImage { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
