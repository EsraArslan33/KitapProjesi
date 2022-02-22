using Kitap_DAL;
using Kitap_DAL.Abstract;

using Kitap_ENTITIES;
using Kitap_ENTITIES.BookVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace KitapProjesi.Controllers
{
    public class BookController : Controller
    { private IGenericDal<Book> repobook;
        private IGenericDal<Category> repocat;
        
        BookVM model = new BookVM();
        public BookController(IGenericDal<Book> _repobook,IGenericDal<Category> _repocat)
        {
            repobook = _repobook;
            repocat = _repocat;
        }
        public IActionResult Index()
        {
            model.blist =repobook.List();
            model.ctlist = repocat.List();
            return View(model);
        }
        public IActionResult Create()
        {
            model.selectListItems = repocat.GenericList().Select(x => new SelectListItem()
            {
                Text = x.CategoryName,
                Value = x.CategoryID.ToString()
            });
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(BookVM bm)
        
        {
            if (ModelState.IsValid)
            {
                Book b = new Book();
                b.BookName = bm.Book.BookName;
                b.Writer = bm.Book.Writer;
                b.CategoryID = bm.Book.CategoryID;
                repobook.Insert(b);
                repobook.Save();                     
            }
            return RedirectToAction("Index");
        }
       
        public IActionResult Update(int id)
        {
            model.Book = repobook.Find(id);
            model.selectListItems = repocat.GenericList().Select(x => new SelectListItem()
            {
                Text=x.CategoryName,
                Value=x.CategoryID.ToString()
            });
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(int id,BookVM bm)
        {
            if (ModelState.IsValid)
            {
                Book b = repobook.Find(id);
                b.BookName = bm.Book.BookName;
                b.Writer = bm.Book.Writer;
                b.CategoryID = bm.Book.CategoryID;
                repobook.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            Book b = repobook.Find(id);
            repobook.Delete(b);
            repobook.Save();
            return RedirectToAction("Index");

        }
        public IActionResult Detail(int id)
        {
            model.Book = repobook.Find(id);
            model.Category = repocat.GenericList().FirstOrDefault(x => x.CategoryID == model.Book.CategoryID);

            return View(model);
        }
    }
}
