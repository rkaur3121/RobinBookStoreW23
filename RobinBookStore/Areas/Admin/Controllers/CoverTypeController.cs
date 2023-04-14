using Microsoft.AspNetCore.Mvc;
using RobinBooks.DataAccess.Repository.IRepository;
using RobinBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobinBookStore.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            CoverType coverType = new CoverType();
            if (id == null)
            {
                return View(coverType);
            }
            coverType = _unitOfWork.Cover.Get(id.GetValueOrDefault());
            if (coverType == null)
            {
                return NotFound();
            }
            return View(coverType);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                if (coverType.Id == 0)
                {
                    _unitOfWork.Cover.Add(coverType);

                }
                else
                {
                    _unitOfWork.Cover.Update(coverType);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(coverType);
        }
        //API Calls Here
        #region
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Cover.GetAll();
            return Json(new { data = allObj });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Cover.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _unitOfWork.Cover.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successfull" });
        }
        #endregion
    }
}