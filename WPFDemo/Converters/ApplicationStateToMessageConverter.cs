using System;
using System.Globalization;
using System.Windows.Data;
using WPFDemo.UserControls.SynchronousAndAsynchronousControl;

namespace WPFDemo.Converters
{
    public class ApplicationStateToMessageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var applicationState = (ApplicationState)value;
            string message;

            switch (applicationState)
            {
                case ApplicationState.Default:
                    message = "Click one of the simulations to begin...";
                    break;
                case ApplicationState.NonResponsive:
                    message = "UI thread is busy, try dragging the window or click on any controls...";
                    break;
                case ApplicationState.Responsive:
                    message = "UI thread is free, try dragging the window or click on any controls...";
                    break;
                default:
                    message = string.Empty;
                    break;
            }

            return message;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
