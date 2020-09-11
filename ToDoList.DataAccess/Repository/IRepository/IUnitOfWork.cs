using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ITaskTypeRepository TaskType { get; }
        IEmployeeRepository Employee { get; }
        ITaskRepository Task { get; }
        ISP_Call SP_Call { get; }

        void Save();
    }
}
