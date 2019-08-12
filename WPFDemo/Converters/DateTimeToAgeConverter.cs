using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFDemo.Converters
{
    public class DateTimeToAgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var birthDate = (DateTime?)value;

            if (!birthDate.HasValue) { return -1; }

            var today = DateTime.Today;
            var age = today.Year - birthDate.Value.Year;

            if (birthDate.Value.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
