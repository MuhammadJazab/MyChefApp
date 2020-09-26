using System;
using System.Collections.Generic;
using System.Text;

namespace MyChefApp.Services
{
    public static class ApiRoutes
    {
        public static class Base
        {
            public static readonly string BaseUrl = "http://192.168.10.6:8800/";
        }

        public static class MyChefAPI
        {
            private static readonly string BaseUrl = "api/Identity/";

            public static readonly string RegisterUser = $"{BaseUrl}RegisterUser";
            public static readonly string UpdateUser = $"{BaseUrl}UpdateUser";
            public static readonly string GetUserByCredentials = $"{BaseUrl}GetUserByCredentials";
            public static readonly string GetFoodList = $"{BaseUrl}GetFoodList";
        }
    }
}
