using System;
using System.Collections.Generic;

namespace MyChefAppModels
{
    public partial class WeekMenu
    {
        public long MenuId { get; set; }
        public string MenuTitle { get; set; }
        public string WeekDay { get; set; }
        public bool IsEven { get; set; }
    }
}
