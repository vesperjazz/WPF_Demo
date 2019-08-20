using WPFDemo.Domain.Models;

namespace WPFDemo.Windows
{
    /// <summary>
    /// Interaction logic for PersonInfoCustomWindow.xaml
    /// </summary>
    public partial class PersonInfoCustomWindow : CustomWindow
    {
        public PersonInfoCustomWindow(PersonInfo personInfo)
        {
            InitializeComponent();
            DataContext = personInfo;
        }
    }
}
