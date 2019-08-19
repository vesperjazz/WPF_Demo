using System.Windows;
using System.Windows.Input;

namespace WPFDemo.LocalResources
{
    public partial class ResourceDictionary
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
    }
}
