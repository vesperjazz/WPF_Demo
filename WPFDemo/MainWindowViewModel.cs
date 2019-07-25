using System;
using System.Windows.Input;

namespace WPFDemo
{
    public class MainWindowViewModel
    {
        public MainWindowModel Model { get; }

        public ICommand UpdateFullNameCommand { get; }
        public ICommand ClearNameCommand { get; }

        public MainWindowViewModel()
        {
            Model = new MainWindowModel();
            UpdateFullNameCommand = new RelayCommand((obj) => UpdateFullName(DateTime.Now), UpdateFullNameCanExecute);
            ClearNameCommand = new RelayCommand((obj) => ClearName(), ClearNameCanExecute);
        }

        public void UpdateFullName(DateTime generatedDateTime)
        {
            Model.FullName = $"{Model.FirstName} {Model.LastName} @ {generatedDateTime.ToString("dd-MMM-yy hh:mm:ss")}";
        }

        public bool UpdateFullNameCanExecute(object param)
        {
            return !string.IsNullOrWhiteSpace(Model.FirstName) && 
                !string.IsNullOrWhiteSpace(Model.LastName);
        }

        public void ClearName()
        {
            Model.FirstName = string.Empty;
            Model.LastName = string.Empty;
        }

        public bool ClearNameCanExecute(object param)
        {
            return !string.IsNullOrWhiteSpace(Model.FirstName) &&
                !string.IsNullOrWhiteSpace(Model.LastName);
        }
    }
}
