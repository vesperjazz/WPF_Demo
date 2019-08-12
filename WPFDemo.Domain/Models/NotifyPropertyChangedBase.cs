using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFDemo.Domain.Models
{
    public class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void UpdateUI([CallerMemberName]string sourcePropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(sourcePropertyName));
        }

        protected void UpdateUI(object sender, [CallerMemberName]string sourcePropertyName = null)
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(sourcePropertyName));
        }
    }
}
