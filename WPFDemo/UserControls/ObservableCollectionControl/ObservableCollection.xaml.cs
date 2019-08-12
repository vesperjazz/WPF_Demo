using System.Windows;
using System.Windows.Controls;

namespace WPFDemo.UserControls.ObservableCollectionControl
{
    /// <summary>
    /// Interaction logic for ObservableCollection.xaml
    /// </summary>
    public partial class ObservableCollection : UserControlBase
    {
        private ObservableCollectionViewModel ViewModel => DataContext as ObservableCollectionViewModel;

        public ObservableCollection()
        {
            InitializeComponent();
        }

        private void PersonInfoDataGrid_DeletePersonClick(object sender, RoutedEventArgs e)
        {
            var btnDeletePerson = sender as Button;
            ViewModel.DeleteObservablePersonCommand.Execute(btnDeletePerson.Tag);
        }

        private void PersonInfoDataGrid_DeleteAllPersonsClicked(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteAllObservablePersonCommand.Execute(null);
        }
    }
}
