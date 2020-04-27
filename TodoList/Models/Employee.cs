using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }

        public virtual string FullName => $"{this.FirstName} {this.LastName}";

        // One Employee to Many Stories
        public virtual List<Story> Stories { get; set; }

        // One Employee to Many StoryTasks
        public virtual List<Story> StoryTasks { get; set; }
    }
}