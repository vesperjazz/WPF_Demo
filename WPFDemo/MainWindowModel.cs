using System.Collections.Generic;
using System.Collections.ObjectModel;
using WPFDemo.Models;

namespace WPFDemo
{
    public class MainWindowModel : ModelBase
    {
        public MainWindowModel()
        {
            _personInfo = new PersonInfo();
            PersonInfoList = new List<PersonInfo>
            {
                new PersonInfo { FirstName = "Aragorn", LastName = "Elessar", SelectedGender = "Male", SelectedJob = new Job { Description = "King of Gondor" } },
                new PersonInfo { FirstName = "Tom", LastName = "Bombadil", SelectedGender = "Male", SelectedJob = new Job { Description = "Nothing" } }

            };
            PersonInfoObservableCollection = new ObservableCollection<PersonInfo>
            {
                new PersonInfo { FirstName = "Aragorn", LastName = "Elessar", SelectedGender = "Male", SelectedJob = new Job { Description = "King of Gondor" } },
                new PersonInfo { FirstName = "Tom", LastName = "Bombadil", SelectedGender = "Male", SelectedJob = new Job { Description = "Nothing" } }
            };
        }

        private PersonInfo _personInfo;
        public PersonInfo PersonInfo
        {
            get { return _personInfo; }
            set { _personInfo = value; }
        }

        public List<PersonInfo> PersonInfoList { get; set; }
        public ObservableCollection<PersonInfo> PersonInfoObservableCollection { get; set; }

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
    }
}
