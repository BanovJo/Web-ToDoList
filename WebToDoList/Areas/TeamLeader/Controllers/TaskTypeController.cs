using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ToDoList.DataAccess.Repository.IRepository;

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


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.TaskType.GetAll();
            return Json(new { data = allObj });
        }
        #endregion
    }
}
    

