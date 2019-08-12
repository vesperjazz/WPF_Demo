using System;
using System.ComponentModel;
using System.Windows;
using WPFDemo.Windows;

namespace WPFDemo.UserControls.CommandsAndCodeBehindControl
{
    /// <summary>
    /// Interaction logic for CommandsAndCodeBehind.xaml
    /// </summary>
    public partial class CommandsAndCodeBehind : UserControlBase
    {
        private CommandsAndCodeBehindViewModel ViewModel => DataContext as CommandsAndCodeBehindViewModel;

        public bool IsEnableButton => ViewModel?.UpdateFullInformationCanExecute(null) ?? false;

        public CommandsAndCodeBehind()
        {
            InitializeComponent();
            DataContextChanged += CommandsAndCodeBehind_DataContextChanged;
        }

        private void CommandsAndCodeBehind_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ViewModel.PersonInfo.PropertyChanged += PersonInfo_PropertyChanged;
        }

        private void PersonInfo_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateUI(nameof(IsEnableButton));
        }

        // Code behind for the respective view must reside in the same 
        // child view(CommandsAndCodeBehind.xaml.cs), not parent view(MainWindow.xaml.cs).
        private void BtnShowFullInfo_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.UpdateFullInformation(DateTime.Now);
        }

        private void BtnOpenWindow_Click(object sender, RoutedEventArgs e)
        {
            var personInfoWindow = new PersonInfoWindow(ViewModel.PersonInfo)
            {
                // Since there is no owner for this window, CenterOwner location is useless.
                // You can set the owner like dialog below, but this is to demonstrate what it's like 
                // for ownerless window.
                WindowStartupLocation = WindowStartupLocation.CenterOwner

                // This will actually have an effect.
                //WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            // Can be opened unlimited times, or at least until your PC's RAM runs out.
            // Your typical multitasking behaviour.
            personInfoWindow.Show();
        }

        private void BtnOpenDialog_Click(object sender, RoutedEventArgs e)
        {
            var personInfoWindow = new PersonInfoWindow(ViewModel.PersonInfo)
            {
                // Setting the owner allows for the blinking effect to take place.
                // Normally setting the owner to this would suffice, but since this is a UserControl, 
                // we'll have to find the Window owner of this UserControl instead.
                Owner = Window.GetWindow(this),
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            // Can only be opened once and focus cannot leave this particular dialog until closure.
            personInfoWindow.ShowDialog();
        }
    }
}
