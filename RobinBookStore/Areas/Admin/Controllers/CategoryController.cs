using Microsoft.AspNetCore.Mvc;
using RobinBooks.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobinsBookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private object allObj;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        //API Calls here
        #region API CALLS 
        [HttpGet]
        public IActionResult GetAll()
        {
            //return NotFound();
            var allobj = _unitOfWork.Category.GetAll();
            return Json(new { data = allObj });

        }
        #endregion
    }
}