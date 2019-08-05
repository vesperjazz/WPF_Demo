using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WPFDemo.Models;

namespace WPFDemo.UserControls.ObservableCollectionControl
{
    public class ObservableCollectionViewModel : INotifyPropertyChanged
    {
        public ICommand DeletePersonCommand { get; }
        public ICommand DeleteObservablePersonCommand { get; }
        public List<PersonInfo> PersonInfoList { get; }
        public ObservableCollection<PersonInfo> PersonInfoObservableCollection { get; }

        public ObservableCollectionViewModel(List<PersonInfo> personInfoList, ObservableCollection<PersonInfo> personInfoObservableCollection)
        {
            PersonInfoList = personInfoList;
            PersonInfoObservableCollection = personInfoObservableCollection;
            DeletePersonCommand = new RelayCommand(DeletePerson);
            DeleteObservablePersonCommand = new RelayCommand(DeleteObservablePerson);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void UpdateUI([CallerMemberName]string sourcePropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(sourcePropertyName));
        }

        private void DeleteObservablePerson(object parameter)
        {
            var personInfo = parameter as PersonInfo;
            PersonInfoObservableCollection.Remove(personInfo);
        }

        private void DeletePerson(object parameter)
        {
            var personInfo = parameter as PersonInfo;
            PersonInfoList.Remove(personInfo);
        }
    }
}
