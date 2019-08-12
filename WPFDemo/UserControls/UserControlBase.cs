using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace WPFDemo.UserControls
{
    public abstract class UserControlBase : UserControl, INotifyPropertyChanged
    {
        //private string _userControlTitle;
        //public string UserControlTitle
        //{
        //    get => _userControlTitle;
        //    set
        //    {
        //        _userControlTitle = value;
        //        UpdateUI();
        //    }
        //}

        //private string _userControlDescription;
        //public string UserControlDescription
        //{
        //    get => _userControlDescription;
        //    set
        //    {
        //        _userControlDescription = value;
        //        UpdateUI();
        //    }
        //}

        public string UserControlTitle { get; set; }
        public List<string> UserControlDescriptions { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        // Convention for this method for Microsoft is OnPropertyChanged, however it seems less intuitive to name it as such.
        // This method is required for all binding on the UI to reflect the latest changes upon value change.
        protected void UpdateUI([CallerMemberName]string sourcePropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(sourcePropertyName));
        }
    }
}
