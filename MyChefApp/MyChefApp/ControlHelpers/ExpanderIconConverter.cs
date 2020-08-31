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
                return ImageSource.FromFile("Add");
            else
                return ImageSource.FromFile("Sub");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}