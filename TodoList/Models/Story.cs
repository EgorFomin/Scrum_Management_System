using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Models
{
    public class Story
    {
        [Key]
        public int Id { get; set; }

        public int StoryPoints { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public int EmployeeId { get; set; }

        // Many Stories to One Employee
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
    }
}