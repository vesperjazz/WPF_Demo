using System;
using System.Collections.Generic;

namespace WPFDemo.Models
{
    public class PersonInfo : ModelBase
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                UpdateUI();
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
            }
        }

        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                UpdateUI();
            }
        }

        private List<Job> _jobs;
        public List<Job> Jobs
        {
            get
            {
                return _jobs ?? (_jobs = new List<Job>
                {
                    new Job { Code = "SE", Description = "Software Engineer" },
                    new Job{Code = "IE", Description = "Infrastructure Engineer" },
                    new Job { Code = "BA", Description = "Business Analyst" },
                    new Job { Code = "SA", Description = "Solution Architect" }
                });
            }
            set { _jobs = value; }
        }

        public Job SelectedJob { get; set; }
        public Guid SelectedJobID { get; set; }

        private List<string> _genders;
        public List<string> Genders
        {
            get { return _genders ?? (_genders = new List<string> { "Male", "Female", "Unknown" }); }
            set { _genders = value; }
        }

        public string SelectedGender { get; set; }
    }
}
