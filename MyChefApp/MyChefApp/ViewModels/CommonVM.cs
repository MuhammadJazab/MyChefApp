namespace MyChefApp.ViewModels
{
    public class Response
    {
        public ResponseStatus Status { get; set; }
        public string Message { get; set; }
        public object ResultData { get; set; }
    }

    public enum ResponseStatus
    {
        OK = 200,
        Error = 400,
        Restrected = 403
    }

    public enum AccountType
    {
        Free = 1,
        Premium = 2,
        FKPremium = 3
    }

    public enum FoodTypeEnum
    {
        Protein = 1,
        Grain = 2,
        Veggie = 3,
        AllergieAndRestriction = 4
    }

    public enum CookingSkills
    {
        FreshMeat = 1,
        SeasonedCook = 2,
        PrepCook = 3,
        LineCook = 4,
        SousChef = 5,
        ExecutiveChef = 6,
    }

    public static class Messages
    {
        public const string InvalidUsers = "Invalid email or password";
        public const string LoginSuccessfully = "LoginSuccessfully";
        public const string UserNotExist = "User does not exit";
    }

    public static class SessionKey
    {
        public const string Token = "Token";
    }
}
