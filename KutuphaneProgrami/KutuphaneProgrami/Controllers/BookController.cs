using BusinessLayer.Concrete;
using DataAccesLayer;
using DataAccesLayer.EntityFramework;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneProgrami.Controllers
{
    [Authorize(Roles = "A")]
    public class BookController : Controller
    {
        Context c = new Context();
        BookManager bm = new BookManager(new EfBookDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var bookvalues = bm.GetList();
            return View(bookvalues);
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            List<SelectListItem> categoryvalue = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.Id.ToString()
                                                  }).ToList();
            List<SelectListItem> writervalue = (from x in wm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WriterName + " " +x.WriterSurname,
                                                      Value = x.Id.ToString()
                                                  }).ToList();
            ViewBag.ctg = categoryvalue;
            ViewBag.writer = writervalue;
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(Book p)
        {
            p.BookAddDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.Status = true;
            bm.BookAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult BookUpdate(int id)
        {
            List<SelectListItem> categoryvalue = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.Id.ToString()
                                                  }).ToList();
            List<SelectListItem> writervalue = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurname,
                                                    Value = x.Id.ToString()
                                                }).ToList();
            ViewBag.ctg = categoryvalue;
            ViewBag.writer = writervalue;
            var bookvalue = bm.GetByID(id);
            return View(bookvalue);
        }
        [HttpPost]
        public ActionResult BookUpdate(Book p)
        {
            bm.BookUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult ActiveOrPassive(int id)
        {
            var bookvalue = bm.GetByID(id);

            if (bookvalue.Status == true)
            {
                bookvalue.Status = false;
            }
            else
            {
                bookvalue.Status = true;
            }
            bm.BookUpdate(bookvalue);
            return RedirectToAction("Index");
        }
    }
}