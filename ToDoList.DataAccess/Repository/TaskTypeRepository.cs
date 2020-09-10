using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoList.DataAccess.Data;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoList.Models;

namespace ToDoList.DataAccess.Repository
{
    public class TaskTypeRepository : Repository<TaskType>, ITaskTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public TaskTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(TaskType taskType)
        {
            var objFromDb = _db.TaskTypes.FirstOrDefault(s => s.TaskTypeId == taskType.TaskTypeId);
            if (objFromDb != null)
            {
                objFromDb.Type = taskType.Type;
                //_db.SaveChanges();
            }
        }
    }
}
