﻿using Microsoft.AspNetCore.Mvc;
using Robinbooks.Models;
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
        public IActionResult Upsert(int? id)  //action method for Upsert
        {
            Category category = new Category();
            if(id ==null)
            {
                //this is for create 
                return View(category);
            }
            //this for the edit 
            category = _unitOfWork.Category.Get(id.GetValueOrDefault());
            if (category == null)
            {
                return NotFound();

            }
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id == 0)
                {
                    _unitOfWork.Category.Add(category);
                }
                else
                {
                    _unitOfWork.Category.Update(category);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
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