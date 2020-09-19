using System;
using System.Collections.Generic;
using System.Text;

namespace MyChefApp.ViewModels
{
    public class FoodVM
    {
        public long FoodId { get; set; }
        public long FoodTypeId { get; set; }
        public string FoodName { get; set; }
        public bool IsSelected { get; set; }
    }
}
