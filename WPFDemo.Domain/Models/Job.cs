using System;

namespace WPFDemo.Domain.Models
{
    public class Job
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
