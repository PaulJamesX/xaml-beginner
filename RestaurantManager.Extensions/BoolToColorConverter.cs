using System;
using Windows.UI;
using Windows.UI.Xaml.Data;

namespace RestaurantManager.Extensions
{
    public class BoolToColorConverter : IValueConverter
    {
        public Color TrueColor { get; set; }
        public Color FalseColor { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Color return_value = Colors.Transparent;
            if (value is bool)
            {
                return_value = (bool)value ? TrueColor : FalseColor;
            }
            return return_value;
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
