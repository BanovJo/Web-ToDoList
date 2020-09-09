using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Models;

namespace ToDoList.DataAccess.Repository.IRepository
{
    public interface ITaskTypeRepository : IRepository<TaskType>
    {
        void Update(TaskType taskType);
    }
}
