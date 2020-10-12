using System;

namespace MyChefApp.ViewModels
{
    public class Chat
    {
        public long Role { get; set; }
        public string Message { get; set; }
        public DateTime DateSent { get; set; }
        public int Status { get; set; }
        public string UserName { get; set; }
    }
}
