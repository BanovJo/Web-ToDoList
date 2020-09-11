using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Models;

namespace ToDoList.DataAccess.Repository.IRepository
{
   public interface IEmployeeRepository : IRepository<Employee>
    {
        void Update(Employee employee);
    }
}
