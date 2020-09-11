using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Models;

namespace ToDoList.DataAccess.Repository.IRepository
{
    public interface ITaskRepository : IRepository<Task>
    {
        void Update(Task task);
    }
}
