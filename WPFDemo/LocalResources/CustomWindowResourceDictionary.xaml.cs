using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFDemo.LocalResources
{
    public partial class CustomWindowResourceDictionary
    {
        private Window GetCurrentWindow(object sender)
        {
            return Window.GetWindow(sender as DependencyObject);
        }

        private void BdrTitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GetCurrentWindow(sender).DragMove();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            GetCurrentWindow(sender).Close();
        }

        private void BtnHide_Click(object sender, RoutedEventArgs e)
        {
            GetCurrentWindow(sender).WindowState = WindowState.Minimized;
        }

        private void BtnMaximiseMinimise_Click(object sender, RoutedEventArgs e)
        {
            var currentSenderWindow = GetCurrentWindow(sender);
            currentSenderWindow.WindowState = currentSenderWindow.WindowState == WindowState.Normal
                ? WindowState.Maximized
                : WindowState.Normal;
        }

        private Thickness _originalBorderMargin = new Thickness(20);
        private Thickness _maximisedBorderMargin = new Thickness(0);
        private void Border_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var border = sender as Border;
            var isInitialSize = e.PreviousSize.Width == 0d && e.PreviousSize.Height == 0d;

            if (isInitialSize) { return; }

            var isSizeIncreased = e.NewSize.Width > e.PreviousSize.Width && e.NewSize.Height > e.PreviousSize.Height;
            border.Margin = isSizeIncreased
                ? _maximisedBorderMargin
                : _originalBorderMargin;
        }
    }
}
