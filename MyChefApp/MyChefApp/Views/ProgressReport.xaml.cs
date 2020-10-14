using MyChefApp.Services;
using MyChefApp.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyChefApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgressReport : ContentPage
    {
        int restrictCount = 30;

        private MediaFile _mediaFile;
        private string URL { get; set; }

        UserVM userVM;

        HttpRequests httpRequests;

        public ProgressReport(UserVM userVM, string skill)
        {
            InitializeComponent();

            this.userVM = userVM;
            httpRequests = new HttpRequests();

            Lbl_XpLevel.Text = skill;
            Lbl_UserName.Text = userVM.UserName;

            Device.BeginInvokeOnMainThread(async () => 
            {
                Busy();
                await FetchAndBindData();
                NotBusy();
            });
        }

        private async Task FetchAndBindData()
        {
            Response goalResponse = await httpRequests.GetUserGoalsByUserId(userVM.UserId);

            Response imageResponse = await httpRequests.GetUserProfileImageByUserId(userVM.UserId);

            txt_Editor.Text = goalResponse.ResultData.ToString();

            string profileImageString = imageResponse?.ResultData?.ToString();

            if (profileImageString?.Length > 0)
            {
                Image_ProfileImage.Source = ImageSource.FromStream(() => new MemoryStream(Encoding.ASCII.GetBytes(profileImageString)));
            }
        }

        private void Editor_Changed(object sender, TextChangedEventArgs e)
        {
            Editor editor = sender as Editor;
            string val = editor.Text; //Get Current Text

            if (val.Length > restrictCount)//If it is more than your character restriction
            {
                val = val.Remove(val.Length - 1);// Remove Last character 
                editor.Text = val; //Set the Old value
            }
        }

        private async void UploadImage(object sender, System.EventArgs e)
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
                    PhotoSize = PhotoSize.Medium
                };

                _mediaFile = await CrossMedia.Current.PickPhotoAsync();

                if (_mediaFile == null) 
                {
                    await DisplayAlert("Error", "There was an error when trying to get your image.", "OK");
                    return;
                }

                UploadImage(_mediaFile.GetStream());

                Image_ProfileImage.Source = ImageSource.FromStream(() => _mediaFile.GetStream());
            }
        }

        private async void UploadImage(Stream stream)
        {
            Busy();

            userVM.ProfileImage = GetByteArrayFromStream(stream);
            await httpRequests.UpdateUser(userVM);
            
            NotBusy();

            await DisplayAlert("Uploaded", "Profile image uploaded Successfully!", "OK");
        }

        public void Busy()
        {
            uploadIndicator.IsVisible = true;
            uploadIndicator.IsRunning = true;
        }

        public void NotBusy()
        {
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

        private async void SaveGoles(object sender, EventArgs e)
        {
            if (txt_Editor.Text.Length > 0)
            {
                userVM.UserGoals = txt_Editor.Text;

                Busy();

                await httpRequests.UpdateUser(userVM);

                NotBusy();

                await DisplayAlert("Uploaded", "Goals uploaded Successfully!", "OK");
            }
        }
    }
}