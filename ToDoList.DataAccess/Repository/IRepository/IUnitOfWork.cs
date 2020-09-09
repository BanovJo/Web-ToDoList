using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ITaskTypeRepository TaskType { get; }
        ISP_Call SP_Call { get; }
    }
}
