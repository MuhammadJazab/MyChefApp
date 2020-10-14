namespace MyChefApp.Services
{
    public static class ApiRoutes
    {
        public static class Base
        {
            /// <summary>
            /// Local
            /// </summary>
            public static readonly string BaseUrl = "http://172.16.2.101:8800/";

            /// <summary>
            /// Live
            /// </summary>
            //public static readonly string BaseUrl = "http://ec2-54-177-128-8.us-west-1.compute.amazonaws.com/";
        }

        public static class MyChefAPI
        {
            private static readonly string BaseUrl = "api/Identity/";

            public static readonly string RegisterUser = $"{BaseUrl}RegisterUser";
            public static readonly string UpdateUser = $"{BaseUrl}UpdateUser";
            public static readonly string GetUserByCredentials = $"{BaseUrl}GetUserByCredentials";
            public static readonly string GetFoodList = $"{BaseUrl}GetFoodList";
            public static readonly string GetCookingSkills = $"{BaseUrl}GetCookingSkills";
            public static readonly string GetWeeklyMenu = $"{BaseUrl}GetWeeklyMenu";
            public static readonly string GetRecipeByMenuId = $"{BaseUrl}GetRecipeByMenuId";
            public static readonly string GetUserProfileImageByUserId = $"{BaseUrl}GetUserProfileImageByUserId";
            public static readonly string GetUserGoalsByUserId = $"{BaseUrl}GetUserGoalsByUserId";
        }
    }
}
