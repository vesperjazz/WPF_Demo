using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;
        }

        private void BasicBinding_AddPersonButtonClicked(object sender, RoutedEventArgs e)
        {
            _viewModel.AddPersonToTable();
        }
    }
}
