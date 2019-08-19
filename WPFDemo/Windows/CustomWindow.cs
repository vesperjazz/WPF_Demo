using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace WPFDemo.Windows
{
    public class CustomWindow : Window
    {
        public Visibility IsHideWindowVisible
        {
            get { return (Visibility)GetValue(IsHideWindowVisibleProperty); }
            set { SetValue(IsHideWindowVisibleProperty, value); }
        }
        public static readonly DependencyProperty IsHideWindowVisibleProperty =
            DependencyProperty.Register("IsHideWindowVisible", typeof(Visibility), typeof(CustomWindow), 
                new PropertyMetadata(Visibility.Collapsed));

        public Visibility IsMaximiseMinimiseVisible
        {
            get { return (Visibility)GetValue(IsMaximiseMinimiseVisibleProperty); }
            set { SetValue(IsMaximiseMinimiseVisibleProperty, value); }
        }
        public static readonly DependencyProperty IsMaximiseMinimiseVisibleProperty =
            DependencyProperty.Register("IsMaximiseMinimiseVisible", typeof(Visibility), typeof(CustomWindow), 
                new PropertyMetadata(Visibility.Collapsed));



        private const string DropShadowEffect = "DropShadowEffect";
        private DropShadowEffect _WindowDropShadowEffect;
        private Color _gray = new Color { A = 255, B = 128, G = 128, R = 128 };
        private Color _lightGray = new Color { A = 255, B = 211, G = 211, R = 211 };

        static CustomWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomWindow),
                new FrameworkPropertyMetadata(typeof(CustomWindow)));
        }

        public CustomWindow()
        {

        }

        public override void OnApplyTemplate()
        {
            if (_WindowDropShadowEffect == null)
            {
                _WindowDropShadowEffect = GetTemplateChild(DropShadowEffect) as DropShadowEffect;
                base.OnApplyTemplate();
            }
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            var source = PresentationSource.FromVisual(this) as HwndSource;
            source.AddHook(WndProc);
            base.OnSourceInitialized(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            var source = PresentationSource.FromVisual(this) as HwndSource;
            source.RemoveHook(WndProc);
            base.OnClosing(e);
        }

        private void Flash(bool active)
        {
            if (_WindowDropShadowEffect != null)
            {
                _WindowDropShadowEffect.Color = active ? _gray : _lightGray;
            }
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            var retVal = IntPtr.Zero;

            switch (msg)
            {
                case 0x0086: //WM_NCACTIVATE message
                    retVal = DefWindowProc(hwnd, 0x0086, new IntPtr(1), new IntPtr(-1));
                    Flash((int)wParam == 1 ? true : false);
                    handled = true;
                    break;
            }

            return retVal;
        }

        [DllImport("user32")]
        internal static extern IntPtr DefWindowProc([In] IntPtr hwnd, [In] int msg, [In] IntPtr wParam, [In] IntPtr lParam);

        private Rect _restoreLocation;
        private Rect _maximizeLocation;
        private bool _isMaximized;
        private bool _mRestoreForDrag = false;

        private void Window_OnSizeChanged(object sender, EventArgs e)
        {
            var senderWindow = sender as Window;

            if (senderWindow.WindowState == WindowState.Maximized)
            {
                _restoreLocation = new Rect { Width = senderWindow.Width, Height = senderWindow.Height, X = senderWindow.Left, Y = senderWindow.Top };
                senderWindow.WindowState = WindowState.Normal;

                foreach (Button button in FindVisualChildren<Button>(senderWindow))
                {
                    if (button.Name == "BtnResize")
                    {
                        Style style = senderWindow.FindResource("MinimizeButtonStyle") as Style;
                        button.Style = style;
                        MaximizeWindow(senderWindow);
                        break;
                    }
                }
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var border = sender as Border;
            var senderWindow = Window.GetWindow(border);
            _mRestoreForDrag = true;

            if (e.ClickCount == 2)
            {
                if (!_isMaximized)
                {
                    foreach (Button button in FindVisualChildren<Button>(border))
                    {
                        if (button.Name == "BtnResize")
                        {
                            Style style = senderWindow.FindResource("MinimizeButtonStyle") as Style;
                            button.Style = style;
                            MaximizeWindow(senderWindow);
                            break;
                        }
                    }
                }
                else if (_isMaximized)
                {
                    foreach (Button button in FindVisualChildren<Button>(border))
                    {
                        if (button.Name == "BtnResize")
                        {
                            Style style = senderWindow.FindResource("MaximizeButtonStyle") as Style;
                            button.Style = style;
                            RestoreWindow(senderWindow);

                            break;
                        }
                    }
                }
            }
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            var border = sender as Border;

            var senderWindow = Window.GetWindow(border);

            if (_isMaximized && e.LeftButton == MouseButtonState.Pressed && _mRestoreForDrag)
            {
                foreach (Button button in FindVisualChildren<Button>(senderWindow))
                {
                    if (button.Name == "BtnResize")
                    {
                        Style style = senderWindow.FindResource("MaximizeButtonStyle") as Style;
                        button.Style = style;

                        var point = senderWindow.PointToScreen(e.MouseDevice.GetPosition(senderWindow));

                        senderWindow.Width = _restoreLocation.Width;
                        senderWindow.Height = _restoreLocation.Height;
                        senderWindow.Left = point.X - (senderWindow.RestoreBounds.Width * 0.5);
                        senderWindow.Top = point.Y;

                        _isMaximized = false;
                        senderWindow.ResizeMode = ResizeMode.CanResizeWithGrip;
                        break;
                    }
                }

                senderWindow.DragMove();
            }
            else if (e.LeftButton == MouseButtonState.Pressed && _mRestoreForDrag)
            {
                senderWindow.DragMove();
            }

            _mRestoreForDrag = false;

        }

        private void BtnResize_Click(object sender, RoutedEventArgs e)
        {
            var resizeButton = sender as Button;
            var senderWindow = Window.GetWindow(resizeButton);

            if (!_isMaximized)
            {
                Style style = senderWindow.FindResource("MinimizeButtonStyle") as Style;
                resizeButton.Style = style;
                MaximizeWindow(senderWindow);
            }
            else if (_isMaximized)

            {
                Style style = senderWindow.FindResource("MaximizeButtonStyle") as Style;
                resizeButton.Style = style;
                RestoreWindow(senderWindow);
            }
        }

        private void BtnHide_Click(object sender, RoutedEventArgs e)
        {
            var hideButton = sender as Button;
            var senderWindow = Window.GetWindow(hideButton);
            senderWindow.WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            var closeButton = sender as Button;
            var senderWindow = Window.GetWindow(closeButton);
            senderWindow.Close();
        }

        private void MaximizeWindow(Window window)
        {
            //WindowsTaskbarHelper taskbarHelper = new WindowsTaskbarHelper();
            //_restoreLocation = new Rect { Width = window.Width, Height = window.Height, X = window.Left, Y = window.Top };
            //System.Windows.Forms.Screen currentScreen;
            //currentScreen = System.Windows.Forms.Screen.FromPoint(System.Windows.Forms.Cursor.Position);

            //Point posOffset = new Point(0, 0);
            //if (taskbarHelper.AutoHide)
            //{
            //    switch (taskbarHelper.Position)
            //    {
            //        case TaskbarPosition.Bottom:
            //            window.Height = currentScreen.WorkingArea.Height - 1;
            //            window.Width = currentScreen.WorkingArea.Width;
            //            window.Left = currentScreen.WorkingArea.X;
            //            window.Top = currentScreen.WorkingArea.Y;
            //            break;
            //        case TaskbarPosition.Top:
            //            window.Height = currentScreen.WorkingArea.Height - 1;
            //            window.Width = currentScreen.WorkingArea.Width;
            //            window.Left = currentScreen.WorkingArea.X;
            //            window.Top = currentScreen.WorkingArea.Y + 1;
            //            break;
            //        case TaskbarPosition.Left:
            //            window.Height = currentScreen.WorkingArea.Height;
            //            window.Width = currentScreen.WorkingArea.Width - 1;
            //            window.Left = currentScreen.WorkingArea.X + 1;
            //            window.Top = currentScreen.WorkingArea.Y;
            //            break;
            //        case TaskbarPosition.Right:
            //            window.Height = currentScreen.WorkingArea.Height;
            //            window.Width = currentScreen.WorkingArea.Width - 1;
            //            window.Left = currentScreen.WorkingArea.X;
            //            window.Top = currentScreen.WorkingArea.Y;
            //            break;
            //    }
            //}
            //else
            //{
            //    window.Height = currentScreen.WorkingArea.Height;
            //    window.Width = currentScreen.WorkingArea.Width;
            //    window.Left = currentScreen.WorkingArea.X;
            //    window.Top = currentScreen.WorkingArea.Y;
            //}

            //_maximizeLocation = new Rect { Width = window.Width, Height = window.Height, X = window.Left, Y = window.Top };
            //_isMaximized = true;
            //window.ResizeMode = ResizeMode.NoResize;
        }

        private void RestoreWindow(Window window)
        {
            if (_restoreLocation != null)
            {
                window.Width = _restoreLocation.Width;
                window.Height = _restoreLocation.Height;
                window.Left = _restoreLocation.Left;
                window.Top = _restoreLocation.Top;

                _isMaximized = false;
                window.ResizeMode = ResizeMode.CanResizeWithGrip;
            }
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
