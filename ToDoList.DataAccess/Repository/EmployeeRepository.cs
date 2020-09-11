using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoList.DataAccess.Data;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoList.Models;

namespace ToDoList.DataAccess.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Employee employee)
        {
            var objFromDb = _db.Employees.FirstOrDefault(s => s.EmployeeId == employee.EmployeeId);
            if (objFromDb != null)
            {
                objFromDb.Name = employee.Name;
                //_db.SaveChanges();
            }
        }
    }
}
