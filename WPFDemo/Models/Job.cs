using System;

namespace WPFDemo.Models
{
    public class Job
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
