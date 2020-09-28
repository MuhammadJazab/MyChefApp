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
    }
}
