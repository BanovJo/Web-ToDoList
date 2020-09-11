using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoList.DataAccess.Data;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoList.Models;

namespace ToDoList.DataAccess.Repository
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        private readonly ApplicationDbContext _db;

        public TaskRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Task task)
        {
            var objFromDb = _db.Tasks.FirstOrDefault(s => s.id == task.id);
            if (objFromDb != null)
            {
                objFromDb.Name = task.Name;
                objFromDb.Dedscription = task.Dedscription;
                objFromDb.TaskTypeId = task.TaskTypeId;
                objFromDb.TaskType = task.TaskType;
                objFromDb.EmployeeId = task.EmployeeId;
                objFromDb.Employee = task.Employee;


                //_db.SaveChanges();
            }
        }
    }
}
