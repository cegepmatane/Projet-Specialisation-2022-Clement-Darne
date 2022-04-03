using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Data.Converters;

namespace Success_History.Converters
{
    public class EqualityConverter : IValueConverter
    {
        public static bool areEqual(string? str1, string? str2)
        {
            if (str1 == null)
            {
                if (str2 == null)
                    return true;
                else
                    return false;
            }
            if (str2 == null)
                return false;

            return (str1 == str2);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string? stringValue = value.ToString();
            string? stringParameter = parameter as string;
            
            return areEqual(stringValue, stringParameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Not supported
            return null;
        }
    }
}
