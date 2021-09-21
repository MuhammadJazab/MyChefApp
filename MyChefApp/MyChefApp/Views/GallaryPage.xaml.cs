using System;
using System.Collections.ObjectModel;
using MyChefApp.Services;
using MyChefApp.ViewModels;
using Xamarin.Forms;

namespace MyChefApp.Views
{
    public partial class GallaryPage : ContentPage
    {
        public GallaryPage(UserVM userVM)
        {
            InitializeComponent();

            var list = new ObservableCollection<ImageGalleryVM>
            {
                new ImageGalleryVM
                {
                    ID = 1,
                    Title = "Yedek parça siparişlerinizde %22' ye varan indirim!",
                    ImagePath = "https://image5.sahibinden.com/photos/08/54/18/x5_719085418j7p.jpg",
                    IsActive = true,
                    CreateDate = DateTime.Now,
                },
                new ImageGalleryVM
                {
                    ID = 2,
                    Title = "Fren Balataları Hangi Sıklıkla Değiştirilmelidir?",
                    ImagePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTJzQfduSrJ3Nh7SHzGSGrCmTnWses4AcfuRSnU7hX4y9XN4TSU&usqp=CAU",
                    IsActive = true,
                    CreateDate = DateTime.Now,
                }
            };

            DeviceStaticsVM helper = DependencyService.Get<IDeviceStatics>().GetDevice();

            double height = 0;
            //double width = helper.ScreenWidth / 2 - 30;

            for (int m = 0; m < 6; m++)
            {
                for (int i = 0; i < list.Count; i++)
                {

                    Frame frame = new Frame
                    {
                        Padding = new Thickness(0, 0, 0, 0)
                    };

                    // Stack
                    StackLayout stack = new StackLayout
                    {
                        Margin = new Thickness(10),
                    };

                    // Image
                    Image image = new Image
                    {
                        Source = list[i].ImagePath,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand
                    };

                    // Title
                    Label title = new Label
                    {
                        Text = list[i].Title,
                        Margin = new Thickness(0, 6, 0, 0),
                        FontSize = 13
                    };

                    // Date
                    Label date = new Label
                    {
                        Text = list[i].CreateDate.ToString().Substring(0, 10), // temporary workaround
                        Margin = new Thickness(0, 6, 0, 0),
                        TextColor = Color.Gray,
                        FontSize = 11
                    };

                    stack.Children.Add(image);
                    stack.Children.Add(title);
                    stack.Children.Add(date);

                    frame.Content = stack;


                    if (i % 2 == 0)
                    {
                        stckLeft.Children.Add(frame);
                    }
                    else
                    {
                        stckRight.Children.Add(frame);

                        SizeRequest columnSizeRequest = frame.Measure(300, 400);
                        height += columnSizeRequest.Request.Height * 6;
                    }
                }
            }
            stckLeft.HeightRequest = height;
            stckRight.HeightRequest = height;

            scrList.HeightRequest = helper.ScreenHeight - 100;
            //stckParent.HeightRequest = list.Count * 100;

        }
    }
}
