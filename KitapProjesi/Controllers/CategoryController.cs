using Kitap_DAL.Abstract;
using Kitap_ENTITIES;
using Kitap_ENTITIES.BookVM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitapProjesi.Controllers
{
    public class CategoryController : Controller
    {
        private IGenericDal<Category> repcat;
        BookVM model = new BookVM();
        public CategoryController(IGenericDal<Category> _repcat)
        {
            repcat = _repcat;
        }
        public IActionResult Index()
        {
            model.ctlist = repcat.List();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(BookVM cm)
        {
            if (ModelState.IsValid)
            {
                Category c = new Category();
                c.CategoryID = cm.Category.CategoryID;
                c.CategoryName = cm.Category.CategoryName;
                repcat.Insert(c);
                repcat.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Update(int id)
        {
            model.Category = repcat.Find(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(int id,BookVM cm)
        {
            if (ModelState.IsValid)
            {
                Category c = repcat.Find(id);
                c.CategoryName = cm.Category.CategoryName;
                repcat.Save();
                RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            Category c = repcat.Find(id);
            repcat.Delete(c);
            repcat.Save();
            return RedirectToAction("Index");
        }
    }
}
