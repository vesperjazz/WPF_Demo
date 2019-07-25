using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WPFDemo
{
    public abstract class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void UpdateUI(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Job
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class MainWindowModel : ModelBase
    {
        /***************************************************
        // This is known as C#'s auto property,
        // where the private backing field is generated 
        // by the compiler upon compilation.
        public int Age { get; set; }

        // Line 15-20 is functionally equivalent to Line 11.
        private int _age;
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        ****************************************************/

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                UpdateUI(nameof(FirstName));
                UpdateUI(nameof(IsEnableButton));
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                UpdateUI(nameof(LastName));
                UpdateUI(nameof(IsEnableButton));
            }
        }

        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                UpdateUI(nameof(FullName));
            }
        }

        public bool IsEnableButton => !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName);


        private List<string> _genders;
        public List<string> Genders
        {
            get { return _genders ?? (_genders = new List<string> { "Male", "Female", "Unknown" }); }
            set { _genders = value; }
        }

        private string _selectedGender;
        public string SelectedGender
        {
            get { return _selectedGender; }
            set { _selectedGender = value; }
        }

        private List<Job> _jobs;
        public List<Job> Jobs
        {
            get { return _jobs ?? (_jobs = new List<Job> { new Job { Code = "SE", Description = "Software Engineer" }, new Job { Code = "BA", Description = "Business Analyst" } }); }
            set { _jobs = value; }
        }

        private Job _selectedJob;
        public Job SelectedJob
        {
            get { return _selectedJob; }
            set { _selectedJob = value; }
        }

        private Guid _selectedJobID;
        public Guid SelectedJobID
        {
            get { return _selectedJobID; }
            set { _selectedJobID = value; }
        }

        public double MaximumProgressBar { get; set; } = 100;
        private bool _isTaskCancellable;
        public bool IsTaskCancellable
        {
            get { return _isTaskCancellable; }
            set
            {
                _isTaskCancellable = value;
                UpdateUI(nameof(IsTaskCancellable));
            }
        }
    }
}
