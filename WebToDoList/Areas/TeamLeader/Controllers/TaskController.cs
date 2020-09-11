using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoList.Models;
using ToDoList.Models.ViewModels;

namespace WebToDoList.Areas.TeamLeader.Controllers
{
    [Area("TeamLeader")]
    public class TaskController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
      //  private readonly IWebHostEnvironment _hostEnvironment; //if we want load image or....

        public TaskController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            TaskVM taskVM = new TaskVM()
            {
                Task = new ToDoList.Models.Task(),
                TypeList = _unitOfWork.TaskType.GetAll().Select(i => new SelectListItem()
                {
                    Text = i.Type,
                    Value = i.TaskTypeId.ToString()
                }) ,
                EmployeeList = _unitOfWork.Employee.GetAll().Select(i => new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.EmployeeId.ToString()
                })

            };
            if (id == null) //create
            {
                return View(taskVM);
            }
            taskVM.Task = _unitOfWork.Task.Get(id.GetValueOrDefault()); //edit
            if (taskVM.Task == null)
            {
                return NotFound();
            }

            return View(taskVM);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Upsert(ToDoList.Models.Task task) //ne radi update id je uvijek 0
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (task.TaskTypeId == 0)
        //        {
        //            _unitOfWork.Task.Add(task);    
        //        }
        //        else
        //        {
        //            _unitOfWork.Task.Update(task);
        //        }
        //        _unitOfWork.Save();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(task);
        //}


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Task.GetAll(includeProperties: "TaskType,Employee");
            return Json(new { data = allObj });
        }

        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Task.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Task.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
    

