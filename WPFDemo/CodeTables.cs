using System.Collections.Generic;
using WPFDemo.Domain.Models;

namespace WPFDemo
{
    public static class CodeTables
    {
        public static List<string> Genders { get; } = new List<string> { "Male", "Female", "Unknown" };

        public static List<Job> Jobs { get; } = new List<Job>
        {
            new Job { Code = "SE", Description = "Software Engineer" },
            new Job { Code = "IE", Description = "Infrastructure Engineer" },
            new Job { Code = "BA", Description = "Business Analyst" },
            new Job { Code = "SA", Description = "Solution Architect" }
        };
    }
}
