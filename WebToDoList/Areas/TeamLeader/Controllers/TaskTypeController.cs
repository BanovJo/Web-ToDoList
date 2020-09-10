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
    public class TaskTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            TaskType taskType = new TaskType();
            if(id == null) //create
            {
                return View(taskType);
            }
            taskType = _unitOfWork.TaskType.Get(id.GetValueOrDefault()); //edit
            if(taskType == null)
            {
                return NotFound();
            }
            

            return View(taskType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(TaskType taskType)
        {
            if (ModelState.IsValid)
            {
                if (taskType.TaskTypeId == 0)
                {
                    _unitOfWork.TaskType.Add(taskType);
                }
                else
                {
                    _unitOfWork.TaskType.Update(taskType);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(taskType);
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.TaskType.GetAll();
            return Json(new { data = allObj });
        }

        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.TaskType.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.TaskType.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
    

