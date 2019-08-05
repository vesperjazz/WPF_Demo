using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFDemo.Models
{
    public abstract class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Convention for this method for Microsoft is OnPropertyChanged, however it seems less intuitive to name it as such.
        // This method is required for all binding on the UI to reflect the latest changes upon value change of the source.
        protected void UpdateUI([CallerMemberName]string sourcePropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(sourcePropertyName));
        }
    }
}
