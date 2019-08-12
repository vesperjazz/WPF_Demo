using System;
using System.Windows.Input;
using WPFDemo.Domain.Models;

namespace WPFDemo.UserControls.CommandsAndCodeBehindControl
{
    public class CommandsAndCodeBehindViewModel : NotifyPropertyChangedBase
    {
        public ICommand UpdateFullInformationCommand { get; }

        public PersonInfo PersonInfo { get; }

        public CommandsAndCodeBehindViewModel(PersonInfo personInfo)
        {
            PersonInfo = personInfo ?? throw new ArgumentNullException(nameof(personInfo));
            UpdateFullInformationCommand = new RelayCommand(UpdateFullInformation, UpdateFullInformationCanExecute);
        }

        public void UpdateFullInformation(object param)
        {
            UpdateUI(PersonInfo, nameof(PersonInfo.FullName));
            UpdateUI(PersonInfo, nameof(PersonInfo.SelectedGender));
            UpdateUI(PersonInfo, nameof(PersonInfo.DateOfBirth));
            UpdateUI(PersonInfo, nameof(PersonInfo.SelectedJob));
        }

        public bool UpdateFullInformationCanExecute(object param)
        {
            return PersonInfo.IsReady;
        }
    }
}
