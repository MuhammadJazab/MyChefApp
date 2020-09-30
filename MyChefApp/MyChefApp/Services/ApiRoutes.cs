﻿namespace MyChefApp.Services
{
    public static class ApiRoutes
    {
        public static class Base
        {
            public static readonly string BaseUrl = "http://172.16.2.101:8800/";
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
        }
    }
}
