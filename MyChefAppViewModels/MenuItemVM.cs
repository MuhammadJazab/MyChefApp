using System;
using System.Collections.Generic;
using System.Text;

namespace MyChefAppViewModels
{
   public class MenuItemVM
    {
        public string Day { get; set; }
        public string Title { get; set; }
        public string Direction { get; set; }
        public List<string> InGridient { get; set; }
    }
}
