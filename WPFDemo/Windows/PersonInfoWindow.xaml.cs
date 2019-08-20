using System.Windows;
using WPFDemo.Domain.Models;

namespace WPFDemo.Windows
{
    /// <summary>
    /// Interaction logic for PersonInfoWindow.xaml
    /// </summary>
    public partial class PersonInfoWindow : Window
    {
        public PersonInfoWindow(PersonInfo personInfo)
        {
            InitializeComponent();
            DataContext = personInfo;
        }
    }
}
