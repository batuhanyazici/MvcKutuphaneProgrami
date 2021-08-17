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
using System.Web.Security;

namespace KutuphaneProgrami.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User p)
        {
            var userinfo = um.GetUser(p.UserMail, p.OriginalPass);
            if (userinfo !=null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.UserMail, false);
                Session["UserMail"] = userinfo.UserMail;
                return RedirectToAction("MyProfile", "UserPanel");
            }
            ViewBag.ErrorMessage = "Kullanıcı Adı veya Şifre Yanlış";
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
        public PartialViewResult UserInfo()
        {
            Context c = new Context();
            string p = (string)Session["UserMail"];
            string name = c.Users.Where(x => x.UserMail == p).Select(y => y.UserName).FirstOrDefault();
            ViewBag.name = name;
            string surname = c.Users.Where(x => x.UserMail == p).Select(y => y.UserSurname).FirstOrDefault();
            ViewBag.surname = surname;
            return PartialView();
        }
    }
}