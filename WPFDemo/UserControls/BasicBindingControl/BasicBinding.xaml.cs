using System.Windows;

namespace WPFDemo.UserControls.BasicBindingControl
{
    /// <summary>
    /// Interaction logic for BasicBinding.xaml
    /// </summary>
    public partial class BasicBinding : UserControlBase
    {
        //public bool IsEnableValidation
        //{
        //    get { return (bool)GetValue(IsEnableValidationProperty); }
        //    set { SetValue(IsEnableValidationProperty, value); }
        //}
        //public static readonly DependencyProperty IsEnableValidationProperty =
        //    DependencyProperty.Register(nameof(IsEnableValidation), typeof(bool), typeof(BasicBinding), 
        //        new PropertyMetadata(true));

        // https://stackoverflow.com/questions/7880850/how-do-i-make-an-event-in-the-usercontrol-and-have-it-handled-in-the-main-form
        public event RoutedEventHandler AddPersonButtonClicked;

        private void BtnAddPersonToTable_Click(object sender, RoutedEventArgs e)
        {
            // Route the event to MainWindow
            AddPersonButtonClicked?.Invoke(sender, e);
        }

        public BasicBinding()
        {
            InitializeComponent();
        }
    }
}
