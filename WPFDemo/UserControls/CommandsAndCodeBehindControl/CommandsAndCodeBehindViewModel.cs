using System;
using System.Windows.Input;
using WPFDemo.Models;

namespace WPFDemo.UserControls.CommandsAndCodeBehindControl
{
    public class CommandsAndCodeBehindViewModel
    {
        public ICommand UpdateFullNameCommand { get; }
        public ICommand ClearNameCommand { get; }

        public PersonInfo PersonInfo { get; }

        public CommandsAndCodeBehindViewModel(PersonInfo personInfo)
        {
            PersonInfo = personInfo ?? throw new ArgumentNullException(nameof(personInfo));
            UpdateFullNameCommand = new RelayCommand((obj) => UpdateFullName(DateTime.Now), UpdateFullNameCanExecute);
            ClearNameCommand = new RelayCommand((obj) => ClearName(), ClearNameCanExecute);
        }

        public void UpdateFullName(DateTime generatedDateTime)
        {
            PersonInfo.FullName = $"{PersonInfo.FirstName} {PersonInfo.LastName} @ {generatedDateTime.ToString("dd-MMM-yy hh:mm:ss")}";
        }

        public bool UpdateFullNameCanExecute(object param = null)
        {
            return !string.IsNullOrWhiteSpace(PersonInfo.FirstName) &&
                !string.IsNullOrWhiteSpace(PersonInfo.LastName);
        }

        public void ClearName()
        {
            PersonInfo.FirstName = string.Empty;
            PersonInfo.LastName = string.Empty;
        }

        public bool ClearNameCanExecute(object param)
        {
            return !string.IsNullOrWhiteSpace(PersonInfo.FirstName) &&
                !string.IsNullOrWhiteSpace(PersonInfo.LastName);
        }
    }
}
