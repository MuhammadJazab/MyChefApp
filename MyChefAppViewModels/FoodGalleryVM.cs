using System;
namespace MyChefAppViewModels
{
    public class FoodGalleryVM
    {
        public long? FoodId { get; set; }
        public long UserId { get; set; }
        public byte[] Image { get; set; }
        public string ImageName { get; set; }
    }
}
