using System;
using System.Collections.Generic;

namespace MyChefAppModels
{
    public partial class FoodGallery
    {
        public long ImageId { get; set; }
        public long? FoodId { get; set; }
        public long UserId { get; set; }
        public byte[] Image { get; set; }
        public string ImageName { get; set; }
    }
}
