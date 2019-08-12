using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPFDemo.Domain.Models;

namespace WPFDemo.UserControls.ObservableCollectionControl
{
    public class ObservableCollectionViewModel : NotifyPropertyChangedBase
    {
        public ICommand DeletePersonCommand { get; }
        public ICommand DeleteAllPersonCommand { get; }

        public ICommand DeleteObservablePersonCommand { get; }
        public ICommand DeleteAllObservablePersonCommand { get; }

        public ObservableCollectionViewModel(List<PersonInfo> personInfoList, ObservableCollection<PersonInfo> personInfoObservableCollection)
        {
            PersonInfoList = personInfoList;
            PersonInfoObservableCollection = personInfoObservableCollection;

            DeletePersonCommand = new RelayCommand(DeletePerson);
            DeleteAllPersonCommand = new RelayCommand(DeleteAllPerson);

            DeleteObservablePersonCommand = new RelayCommand(DeleteObservablePerson);
            DeleteAllObservablePersonCommand = new RelayCommand(DeleteAllObservablePerson);
        }

        public ObservableCollection<PersonInfo> PersonInfoObservableCollection { get; }
        private void DeleteObservablePerson(object parameter)
        {
            var personInfo = parameter as PersonInfo;
            PersonInfoObservableCollection.Remove(personInfo);
        }

        private void DeleteAllObservablePerson(object parameter)
        {
            PersonInfoObservableCollection.Clear();
        }

        public List<PersonInfo> PersonInfoList { get; set; }
        private void DeletePerson(object parameter)
        {
            var personInfo = parameter as PersonInfo;
            PersonInfoList.Remove(personInfo);

            // Uncomment this line for and its properties above to make 
            // the delete work.
            // Very expensive operation to construct an entire list just to change
            // the binding's reference.
            //PersonInfoList = PersonInfoList.ConvertAll(p => p);
            //UpdateUI(nameof(PersonInfoList));
        }

        private void DeleteAllPerson(object parameter)
        {
            PersonInfoList.Clear();
            //PersonInfoList = new List<PersonInfo>();
            //UpdateUI(nameof(PersonInfoList));
        }
    }
}
