using System;
using System.ComponentModel;
using System.Diagnostics;

namespace WPFDemo.Domain.Models
{
    [DebuggerDisplay("FirstName = {FirstName.GetHashCode()}, SelectedJob = {SelectedJob.GetHashCode()}")]
    public class PersonInfo : NotifyPropertyChangedBase, IDataErrorInfo
    {
        // Property in C# is like a private field in Java with a public getter and setter.
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                UpdateUI();
                UpdateUI(nameof(IsReady));
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                UpdateUI();
                UpdateUI(nameof(IsReady));
            }
        }

        public DateTime? DateOfBirth { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        // Auto property, the compiler generates its own private backing field!
        // No need for private field as this does not have a direct binding on the UI.
        public string SelectedGender { get; set; }

        // Exactly the same as the above, unnecessary and makes the code messy.
        //private string _selectedGender;
        //public string SelectedGender
        //{
        //    get { return _selectedGender; }
        //    set { _selectedGender = value; }
        //}

        public Job SelectedJob { get; set; }
        public Guid SelectedJobID { get; set; }

        // It is advisable to have a defined default constructor even when the compiler generates one for you.
        // During debugging, you can place a breakpoint here and immediately know where this class is being constructed.
        // References are reliable up to a certain point, but if the class were to be constructed or triggered by some 
        // external controls/XAML events, it's not gonna appear in the references and it will drive you NUTS.
        // Just do it, you'll thank yourself soon enough.
        public PersonInfo()
        {

        }

        public PersonInfo Clone()
        {
            return (PersonInfo)MemberwiseClone();
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                string errorMessage = null;

                switch (columnName)
                {
                    case nameof(LastName):
                        if (string.IsNullOrWhiteSpace(LastName))
                        {
                            errorMessage = "Last Name cannot be empty.";
                        }
                        break;
                    case nameof(FirstName):
                        if (string.IsNullOrWhiteSpace(FirstName))
                        {
                            errorMessage = "First Name cannot be empty.";
                        }
                        break;
                }

                return errorMessage;
            }
        }

        public bool IsReady => !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName);
    }
}
