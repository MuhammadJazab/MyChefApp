using System;
namespace MyChefApp.ViewModels
{
    public class ImageGalleryVM
    {
        public int? ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
