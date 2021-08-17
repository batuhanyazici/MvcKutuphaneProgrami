using BusinessLayer.Concrete;
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
    public class BorrowBooksController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());
        BookManager bm = new BookManager(new EfBookDal());
        BorrowManager brm = new BorrowManager(new EfBorrowDal());
        public ActionResult BookBorrow()
        {
            var bookvalues = brm.GetList();
            return View(bookvalues);
        }
        public ActionResult BringBook()
        {
            return View();
        }
        public ActionResult GiveBook()
        {
            List<SelectListItem> userinfo = (from x in um.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.UserName+" "+ x.UserSurname,
                                                      Value = x.Id.ToString()
                                                  }).ToList();
            List<SelectListItem> bookinfo = (from x in bm.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.BookName,
                                                 Value = x.Id.ToString()
                                             }).ToList();
            ViewBag.users = userinfo;
            ViewBag.books = bookinfo;
            return View();
        }
        [HttpGet]
        public ActionResult AddBorrow()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBorrow(Borrow p)
        {
            brm.BorrowAdd(p);
            return RedirectToAction("BookBorrow");
        }
        public ActionResult BorrowUpdate(int id)
        {
            List<SelectListItem> userinfo = (from x in um.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.UserName + " " + x.UserSurname,
                                                 Value = x.Id.ToString()
                                             }).ToList();
            List<SelectListItem> bookinfo = (from x in bm.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.BookName,
                                                 Value = x.Id.ToString()
                                             }).ToList();
            ViewBag.users = userinfo;
            ViewBag.books = bookinfo;
            var bookvalue = brm.GetByID(id);
            return View(bookvalue);
        }
        [HttpPost]
        public ActionResult BorrowUpdate(Borrow p)
        {
            brm.BorrowUpdate(p);
            return RedirectToAction("BookBorrow");
        }
        public ActionResult IsCome(int id)
        {
            var borrowvalue= brm.GetByID(id);
            borrowvalue.IsCome = true;
            brm.BorrowUpdate(borrowvalue);
            return RedirectToAction("BookBorrow");
        }
    }
}