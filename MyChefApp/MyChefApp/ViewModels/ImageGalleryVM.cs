using System;
using Xamarin.Forms;

namespace MyChefApp.ViewModels
{
    public class ImageGalleryVM
    {
        public long ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ImageSource ImageSource { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
