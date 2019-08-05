using System;
using System.ComponentModel;
using System.Windows;

namespace WPFDemo.UserControls.CommandsAndCodeBehindControl
{
    /// <summary>
    /// Interaction logic for CommandsAndCodeBehind.xaml
    /// </summary>
    public partial class CommandsAndCodeBehind : UserControlBase
    {
        private CommandsAndCodeBehindViewModel ViewModel => DataContext as CommandsAndCodeBehindViewModel;

        public bool IsEnableButton => ViewModel?.UpdateFullNameCanExecute() ?? false;

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
            ViewModel.UpdateFullName(DateTime.Now);
        }
    }
}
