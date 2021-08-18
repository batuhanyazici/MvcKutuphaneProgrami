using BusinessLayer.Concrete;
using DataAccesLayer;
using DataAccesLayer.EntityFramework;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneProgrami.Controllers
{
    public class UserPanelController : Controller
    {
        Context c = new Context();
        UserManager um = new UserManager(new EfUserDal());
        BookManager bm = new BookManager(new EfBookDal());
        BorrowManager brm = new BorrowManager(new EfBorrowDal());
        RequestManager rn = new RequestManager(new EfRequestDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MyProfile(string p)
        {
            p = (string)Session["UserMail"];
            var useridinfo = c.Users.Where(x => x.UserMail == p).Select(y => y.Id).FirstOrDefault();
            var uservalues = um.GetListById(useridinfo);
            ViewBag.userid = useridinfo;
            return View(uservalues);
        }
        [HttpGet]
        public ActionResult UserUpdate(int id)
        {
            string p = (string)Session["UserMail"];
            var useridinfo = c.Users.Where(x => x.UserMail == p).Select(y => y.Id).FirstOrDefault();
            var uservalue = um.GetByID(useridinfo);
            return View(uservalue);
        }
        [HttpPost]
        public ActionResult UserUpdate(User p)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string writerpassword = p.UserPassword;
            string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(writerpassword)));
            p.UserPassword = result;
            string k = (string)Session["UserMail"];
            var userroleinfo = c.Users.Where(x => x.UserMail == k).Select(y => y.Role).FirstOrDefault();
            p.Role = userroleinfo;
            um.UserUpdate(p);
            return RedirectToAction("MyProfile");
        }
        public ActionResult Books()
        {
            var books = bm.GetList();
            return View(books);
        }
        [HttpGet]
        public ActionResult MyBorrowBooks()
        {
            string p = (string)Session["UserMail"];
            var useridinfo = c.Users.Where(x => x.UserMail == p).Select(y => y.Id).FirstOrDefault();
            var deneme = c.Borrows.ToList().Where(x => x.UserId == useridinfo).ToList();
            return View(deneme);
        }
        public ActionResult BorrowRequest()
        {
            string p = (string)Session["UserMail"];
            var useridinfo = c.Users.Where(x => x.UserMail == p).Select(y => y.Id).FirstOrDefault();
            var values = c.BorrowRequests.ToList().Where(x => x.UserId == useridinfo).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult BorrowRequestAdd()
        {
            List<SelectListItem> bookinfo = (from x in bm.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.BookName,
                                                 Value = x.Id.ToString()
                                             }).ToList();
            ViewBag.books = bookinfo;
            return View();
        }
        [HttpPost]
        public ActionResult BorrowRequestAdd(BorrowRequest p)
        {
            string v = (string)Session["UserMail"];
            var useridinfo = c.Users.Where(x => x.UserMail == v).Select(y => y.Id).FirstOrDefault();
            p.UserId = useridinfo;
            rn.BorrowRequestAdd(p);
            return RedirectToAction("BorrowRequest");
        }
    }
}