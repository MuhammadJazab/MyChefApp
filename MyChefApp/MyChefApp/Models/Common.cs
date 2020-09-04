using System;
using System.Collections.Generic;
using System.Text;

namespace MyChefApp.Models
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

    public static class TableName
    {
        public const string UserTable = "Users";
    }

    public static class Messages
    {
        public const string InvalidUsers = "Invalid email or password";
        public const string LoginSuccessfully = "LoginSuccessfully";
    }
}
