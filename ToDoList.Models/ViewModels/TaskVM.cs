using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Models.ViewModels
{
   public class TaskVM
    {
        public ToDoList.Models.Task Task { get; set; }
        public IEnumerable<SelectListItem> TypeList { get; set; }
        public IEnumerable<SelectListItem> EmployeeList { get; set; }
    }
}
