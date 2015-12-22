using System;
using Windows.UI;
using Windows.UI.Xaml.Data;

namespace RestaurantManager.Extensions
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Color rv = Colors.Transparent;
            if (value is bool)
            {
                rv = (bool)value ? Colors.Red : Colors.Green;
            }
            return rv;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            bool rv = default(bool);
            if (value is Color)
            {
                if ((Color)value == Colors.Green)
                {
                    rv = false;
                }
                if ((Color)value == Colors.Red)
                {
                    rv = true;
                }
            }
            return rv;
        }

    }
}
