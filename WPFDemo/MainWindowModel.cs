using System.Collections.Generic;
using System.Collections.ObjectModel;
using WPFDemo.Domain.Models;

namespace WPFDemo
{
    public class MainWindowModel : NotifyPropertyChangedBase
    {
        public PersonInfo PersonInfo { get; set; }
        public List<PersonInfo> PersonInfoList { get; }
        public ObservableCollection<PersonInfo> PersonInfoObservableCollection { get; }

        private bool _isUserControlTaskCancellable;
        public bool IsUserControlTaskCancellable
        {
            get { return _isUserControlTaskCancellable; }
            set
            {
                _isUserControlTaskCancellable = value;
                UpdateUI();
            }
        }

        public MainWindowModel()
        {
            PersonInfo = new PersonInfo { IsEnableValidation = true };
            PersonInfoList = new List<PersonInfo>
            {
                new PersonInfo { FirstName = "Aragorn", LastName = "Elessar", SelectedGender = "Male", SelectedJob = new Job { Description = "King of Gondor" } },
                new PersonInfo { FirstName = "Arwen", LastName = "Undomiel", SelectedGender = "Female", SelectedJob = new Job { Description = "Queen of Gondor" } },
                new PersonInfo { FirstName = "Gandalf", LastName = "Greyhame", SelectedGender = "Male", SelectedJob = new Job { Description = "Wizard" } }

            };
            PersonInfoObservableCollection = new ObservableCollection<PersonInfo>
            {
                new PersonInfo { FirstName = "Aragorn", LastName = "Elessar", SelectedGender = "Male", SelectedJob = new Job { Description = "King of Gondor" } },
                new PersonInfo { FirstName = "Arwen", LastName = "Undomiel", SelectedGender = "Female", SelectedJob = new Job { Description = "Queen of Gondor" } },
                new PersonInfo { FirstName = "Gandalf", LastName = "Greyhame", SelectedGender = "Male", SelectedJob = new Job { Description = "Wizard" } }
            };
        }
    }
}
