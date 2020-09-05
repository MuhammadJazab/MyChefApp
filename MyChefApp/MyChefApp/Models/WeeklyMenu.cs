using System;
using System.Collections.Generic;
using System.Text;

namespace MyChefApp.Models
{
    public class WeeklyMenu
    {
        public long MenuID { get; set; }
        public string Day { get; set; }
        public string Title { get; set; }
        public bool IsEven { get; set; }
    }
}
