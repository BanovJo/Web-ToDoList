using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoList.Models;

namespace WebToDoList.Areas.TeamLeader.Controllers
{
    [Area("TeamLeader")]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            ToDoList.Models.Employee EmployeeController = new ToDoList.Models.Employee();
            if (id == null) //create
            {
                return View(EmployeeController);
            }
            EmployeeController = _unitOfWork.Employee.Get(id.GetValueOrDefault()); //edit
            if (EmployeeController == null)
            {
                return NotFound();
            }

            return View(EmployeeController);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ToDoList.Models.Employee EmployeeController) //ne radi update id je uvijek 0
        {
            if (ModelState.IsValid)
            {
                if (EmployeeController.EmployeeId == 0)
                {
                    _unitOfWork.Employee.Add(EmployeeController);    
                }
                else
                {
                    _unitOfWork.Employee.Update(EmployeeController);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(EmployeeController);
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Employee.GetAll();
            return Json(new { data = allObj });
        }

        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Employee.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Employee.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
    

