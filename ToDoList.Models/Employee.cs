using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoList.Models
{
  public  class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [DisplayName("Employee name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
