using System;
using WPFDemo.Domain.Models;

namespace WPFDemo.UserControls.SynchronousAndAsynchronousControl
{
    public class SynchronousAndAsynchronousViewModel
    {
        public PersonInfo PersonInfo { get; }
        public SynchronousAndAsynchronousViewModel(PersonInfo personInfo)
        {
            PersonInfo = personInfo ?? throw new ArgumentNullException(nameof(personInfo));
        }
    }
}
