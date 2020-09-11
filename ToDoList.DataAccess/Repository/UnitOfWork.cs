using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.DataAccess.Data;
using ToDoList.DataAccess.Repository.IRepository;

namespace ToDoList.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            TaskType = new TaskTypeRepository(_db);
            Employee = new EmployeeRepository(_db);
            Task = new TaskRepository(_db);
            SP_Call = new SP_Call(_db);
        }

        public ITaskTypeRepository TaskType { get; private set; }
        public IEmployeeRepository Employee { get; private set; } 
        public ITaskRepository Task { get; private set; } 
        public ISP_Call SP_Call { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
