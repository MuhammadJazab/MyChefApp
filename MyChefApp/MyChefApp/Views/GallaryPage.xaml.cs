using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using MyChefApp.Services;
using MyChefApp.ViewModels;
using MyChefAppViewModels;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MyChefApp.Views
{
    public partial class GallaryPage : ContentPage
    {
        HttpRequests httpRequests;

        DeviceStaticsVM helper;
        ObservableCollection<ImageGalleryVM> imageGalleryVMs;

        public GallaryPage(UserVM userVM)
        {
            InitializeComponent();

            httpRequests = new HttpRequests();

            helper = DependencyService.Get<IDeviceStatics>().GetDevice();

            GetData();

            if (imageGalleryVMs.Count > 0)
                BindData(imageGalleryVMs);
            else Lbl_NoImage.IsVisible = true;
        }

        private async void GetData()
        {
            Response response = await httpRequests.GetFoodGallery();

            if (response.Status == ResponseStatus.OK)
            {
                List<FoodGalleryVM> foodGalleryVMs = JsonConvert.DeserializeObject<List<FoodGalleryVM>>(response.ResultData.ToString());

                if (foodGalleryVMs.Count > 0)
                {
                    imageGalleryVMs = new ObservableCollection<ImageGalleryVM>();

                    foreach (var foodGalleryVM in foodGalleryVMs)
                    {
                        imageGalleryVMs.Add(new ImageGalleryVM
                        {
                            ID = foodGalleryVM.ImageId,
                            Title = foodGalleryVM.ImageName,
                            ImageSource = ImageSource.FromStream(() => new MemoryStream(foodGalleryVM.Image)),
                            IsActive = true,
                            CreateDate = DateTime.Now,
                        });
                    }

                    //,new ImageGalleryVM
                    //{
                    //    ID = 2,
                    //    Title = "Dish Name",
                    //    //ImagePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTJzQfduSrJ3Nh7SHzGSGrCmTnWses4AcfuRSnU7hX4y9XN4TSU&usqp=CAU",
                    //    ImagePath = "four",
                    //    IsActive = true,
                    //    CreateDate = DateTime.Now,
                    //}
                }
                else
                {
                    await DisplayAlert("Alert", "No images found", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", response.Message, "OK");
            }
        }

        private void BindData(ObservableCollection<ImageGalleryVM> list)
        {
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
                        Source = list[i].ImageSource,
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
