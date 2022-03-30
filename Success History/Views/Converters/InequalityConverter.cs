using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Data.Converters;

namespace Success_History.Views.Converters
{
    public class InequalityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string? stringValue = value.ToString();
            string? stringParameter = parameter as string;
            
            return !EqualityConverter.areEqual(stringValue, stringParameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Not supported
            return null;
        }
    }
}
