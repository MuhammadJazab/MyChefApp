using MyChefApp.Services;
using MyChefApp.ViewModels;
using MyChefAppViewModels;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        string skill;

        int restrictCount = 30;

        MediaFile _mediaFile;

        UserVM userVM;

        HttpRequests httpRequests;

        List<GoalsVM> goalsVMs;
        ObservableCollection<GoalsVM> observableGoalsVMs;

        public ProgressReport(UserVM userVM, string skill)
        {
            InitializeComponent();

            this.userVM = userVM;
            this.skill = skill;

            httpRequests = new HttpRequests();

            observableGoalsVMs = new ObservableCollection<GoalsVM>();

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

            if (goalResponse.Status == ResponseStatus.OK)
            {
                goalsVMs = JsonConvert.DeserializeObject<List<GoalsVM>>(goalResponse?.ResultData?.ToString());

                if (goalsVMs.Count > 0)
                {
                    foreach (var goal in goalsVMs)
                    {
                        observableGoalsVMs.Add(goal);
                    }

                    listView_MyGoals.ItemsSource = observableGoalsVMs;
                }
            }
            else if (goalResponse.Status == ResponseStatus.Restrected)
            {
                await DisplayAlert("Error", goalResponse.Message, "OK");
            }
            else
            {
                await DisplayAlert("Error", goalResponse.Message, "OK");
            }

            if (imageResponse.Status == ResponseStatus.OK)
            {
                byte[] profileImageString = JsonConvert.DeserializeObject<byte[]>(imageResponse?.ResultData.ToString());

                if (profileImageString?.Length > 0)
                {
                    Image_ProfileImage.Source = ImageSource.FromStream(() => new MemoryStream(profileImageString));
                }
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
                Busy();

                GoalsVM goalsVM = new GoalsVM()
                {
                    UserId = userVM.UserId,
                    GoalCompleted = false,
                    GoalText = txt_Editor.Text
                };

                Response response = await httpRequests.SetUserGoalsByUserId(goalsVM);

                NotBusy();

                if (response.Status == ResponseStatus.OK)
                {
                    txt_Editor.Text = string.Empty;

                    await DisplayAlert("Uploaded", response.Message, "OK");

                    App.Current.MainPage = new NavigationPage(new ProgressReport(userVM, skill));
                }
                else if (response.Status == ResponseStatus.Restrected)
                {
                    await DisplayAlert("Error", response.Message, "OK");
                }
                else
                {
                    await DisplayAlert("Exception", response.Message, "OK");
                }
            }
        }

        private async void CheckBox_StateChanged(object sender, StateChangedEventArgs e)
        {
            Response response = await httpRequests.UpdateGoalByGoalId(Convert.ToInt64(((SfCheckBox)sender).AutomationId), e.IsChecked);
        }
    }
}