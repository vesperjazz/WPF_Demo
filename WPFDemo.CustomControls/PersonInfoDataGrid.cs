using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFDemo.CustomControls
{
    public class PersonInfoDataGrid : DataGrid
    {
        private const string PersonInfoDataGridName = "DtgPersonInfo";
        private const string DeletePersonButtonName = "BtnDeletePerson";
        private const string DeleteAllPersonsButtonName = "BtnDeleteAllPersons";

        static PersonInfoDataGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PersonInfoDataGrid), 
                new FrameworkPropertyMetadata(typeof(PersonInfoDataGrid)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var dtgPersonInfo = GetTemplateChild(PersonInfoDataGridName) as DataGrid;

            dtgPersonInfo.PreviewMouseLeftButtonUp += DataGrid_PreviewMouseLeftButtonUp;
        }

        public event RoutedEventHandler DeletePersonClicked;
        public event RoutedEventHandler DeleteAllPersonsClicked;

        private void DataGrid_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var control = e.OriginalSource as Control;
            if(control.Name == DeletePersonButtonName)
            {
                DeletePersonClicked?.Invoke(control, null);
            }
            else if(control.Name == DeleteAllPersonsButtonName)
            {
                DeleteAllPersonsClicked?.Invoke(control, null);
            }

            e.Handled = true;
        }
    }
}
