using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductBasket.DataAccess.IRepository;
using ProductBasket.Models;

namespace ProductBasket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            Product product = new Product();
            if (id == null)
            {
                return View(product);
            }
            product = _unitOfWork.Product.Get(id.GetValueOrDefault());
            if(product==null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.Id == 0)
                {
                    _unitOfWork.Product.Add(product);
                   
                }
                else
                {
                    _unitOfWork.Product.Update(product);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Product.GetAll();
            return Json(new { data = allObj });
        }
        #endregion
    }
}
