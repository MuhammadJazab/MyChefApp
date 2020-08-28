using System;
using System.Globalization;
using Xamarin.Forms;

namespace MyChefApp.ControlHelpers
{
    public class ExpanderIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                var aa = ImageSource.FromResource("Add.png");
                return ImageSource.FromResource("Add.png");
            }
            else
                return ImageSource.FromResource("Sub.png");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
