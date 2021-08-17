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
            var uservalue = um.GetByID(id);
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
    }
}