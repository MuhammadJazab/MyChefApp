using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using MyChefApp.Services;
using MyChefApp.ViewModels;
using MyChefAppViewModels;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace MyChefApp.Views
{
    public partial class GallaryPage : ContentPage
    {
        HttpRequests httpRequests;

        UserVM userVM;

        DeviceStaticsVM helper;
        ObservableCollection<ImageGalleryVM> imageGalleryVMs;

        public GallaryPage(UserVM userVM)
        {
            InitializeComponent();

            this.userVM = userVM;

            httpRequests = new HttpRequests();

            helper = DependencyService.Get<IDeviceStatics>().GetDevice();

            GetData();
        }

        private async void GetData()
        {
            Busy();

            Response response = await httpRequests.GetFoodGallery();

            if (response?.Status == ResponseStatus.OK)
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
                }
                else
                {
                    await DisplayAlert("Alert", "No images found", "OK");
                }

                if (imageGalleryVMs?.Count > 0)
                    BindData(imageGalleryVMs);
                else Lbl_NoImage.IsVisible = true;
            }
            else
            {
                Lbl_NoImage.IsVisible = true;
            }

            NotBusy();
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

        async void AddImage_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Error", "This is not support on your device.", "OK");
                return;
            }
            else
            {
                var mediaOption = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium,
                    SaveMetaData = true,
                    CompressionQuality = 80,
                    ModalPresentationStyle = MediaPickerModalPresentationStyle.FullScreen
                };

                var _mediaFile = await CrossMedia.Current.PickPhotoAsync(mediaOption);

                if (_mediaFile == null)
                {
                    await DisplayAlert("Error", "There was an error when trying to get your image.", "OK");
                    return;
                }

                await UploadImage(_mediaFile);

                GetData();
            }
        }

        private async Task UploadImage(MediaFile _mediaFile)
        {
            string foodName = await DisplayPromptAsync("Food Image", "Enter name of the Food you have selected", maxLength: 20, keyboard: Keyboard.Text);

            Busy();

            FoodGalleryVM foodGalleryVM = new FoodGalleryVM()
            {
                Image = GetByteArrayFromStream(_mediaFile.GetStream()),
                ImageName = foodName,
                UserId = userVM.UserId
            };

            Response response = await httpRequests.UploadFoodImage(foodGalleryVM);

            if (response?.Status == ResponseStatus.OK)
                await DisplayAlert("Uploaded Successfull", "Profile image uploaded Successfully!", "OK");
            else await DisplayAlert("Uploaded Failed", string.IsNullOrWhiteSpace(response?.Message) ? "Error while uploading the image." : response?.Message, "OK");

            NotBusy();
        }

        public void Busy()
        {
            Btn_AddImage.IsEnabled = false;
            uploadIndicator.IsVisible = true;
            uploadIndicator.IsRunning = true;
        }

        public void NotBusy()
        {
            Btn_AddImage.IsEnabled = true;
            uploadIndicator.IsVisible = false;
            uploadIndicator.IsRunning = false;
        }

        public static byte[] GetByteArrayFromStream(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];

            using (MemoryStream ms = new MemoryStream())
            {
                int read;

                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                return ms.ToArray();
            }
        }
    }
}
