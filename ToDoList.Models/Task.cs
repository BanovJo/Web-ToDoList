using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text;

namespace ToDoList.Models
{
    public class Task
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Task name")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Description")]
        [Required]
        public string Dedscription { get; set; }

        [Required]
        public int TaskTypeId { get; set; }
        [ForeignKey("TaskTypeId")]

        [DisplayName("Type")]
        public TaskType TaskType { get; set; }
        [Required]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        [DisplayName("Employee name")]
        public Employee Employee { get; set; }

    }
}
