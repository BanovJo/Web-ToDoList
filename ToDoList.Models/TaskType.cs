using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoList.Models
{
  public  class TaskType
    {
        [Key]
        public int TaskTypeId { get; set; }

        [DisplayName("Task type")]
        [Required]
        [MaxLength(50)]
        public string Type { get; set; }
    }
}
