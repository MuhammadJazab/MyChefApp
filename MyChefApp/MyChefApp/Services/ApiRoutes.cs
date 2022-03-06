namespace MyChefApp.Services
{
    public static class ApiRoutes
    {
        public static class Base
        {
            /// <summary>
            /// Local
            /// </summary>
            //public static readonly string BaseUrl = "http://localhost:8800/";

            //Android
            //public static readonly string BaseUrl = "http://10.0.2.2:8800/";

            /// <summary>
            /// Live
            /// </summary>
            public static readonly string BaseUrl = "http://mychefserver.gearhostpreview.com/";
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
            public static readonly string UpdateGoalByGoalId = $"{BaseUrl}UpdateGoalByGoalId";

            /// <summary>
            /// Type: Get
            /// Paramaeter: long userId
            /// </summary>
            public static readonly string GetUserGoalsByUserId = $"{BaseUrl}GetUserGoalsByUserId";

            /// <summary>
            /// Type: Post
            /// Paramaeter: GoalsVM goalsVM
            /// </summary>
            public static readonly string SetUserGoalsByUserId = $"{BaseUrl}SetUserGoalsByUserId";
        }
    }
}
