using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyChefApp.ViewModels
{
    public class WeekMenuVM
    {
        public long MenuId { get; set; }
        public string MenuTitle { get; set; }
        public string WeekDay { get; set; }
        public bool IsEven { get; set; }
    }
}
