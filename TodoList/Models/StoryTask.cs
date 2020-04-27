using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class StoryTask
    {
        [Key]
        public int Id { get; set; }

        public int Estimation { get; set; } // minutes

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public int EmployeeId { get; set; }

        // Many StoryTask to One Employee
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        public int StoryId { get; set; }

        // Many Story to One Employee
        [ForeignKey("StoryId")]
        public virtual Story Story { get; set; }
    }
}