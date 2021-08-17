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
    [Authorize(Roles = "A")]
    public class UserController : Controller
    {
        Context c = new Context();
        UserManager um = new UserManager(new EfUserDal());
        public ActionResult Index()
        {
            var users = um.GetList();
            return View(users);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User p)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string writerpassword = p.UserPassword;
            string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(writerpassword)));
            p.UserPassword = result;
            p.OriginalPass = writerpassword;
            p.SignDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.UserStatus = true;
            um.UserAdd(p);
            return RedirectToAction("Index");
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
            p.Role = "U";
            um.UserUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult ActiveOrPassive(int id)
        {
            var uservalue = um.GetByID(id);

            if (uservalue.UserStatus == true)
            {
                uservalue.UserStatus = false;
            }
            else
            {
                uservalue.UserStatus = true;
            }
            um.UserUpdate(uservalue);
            return RedirectToAction("Index");
        }
    }
}