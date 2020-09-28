using System;
using System.Collections.Generic;
using System.Text;

namespace MyChefApp.ViewModels
{
    public class Chat
    {
        public int Role { get; set; }
        public string Message { get; set; }
        public DateTime DateSent { get; set; }
        public int Status { get; set; }
    }
}
