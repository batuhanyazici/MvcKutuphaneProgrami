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
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var categories = cm.GetList();
            return View(categories);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CategoryAdd(Category p)
        {
            cm.CategoryAdd(p);
            return RedirectToAction("Index");
        }
        public PartialViewResult CategoryAddMenu()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult CategoryUpdate(int id)
        {
            var categoryvalue = cm.GetByID(id);
            return View(categoryvalue);
        }

        [HttpPost]
        public ActionResult CategoryUpdate(Category p)
        {
            cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult ActiveOrPassive(int id)
        {
            var categoryvalue = cm.GetByID(id);

            if (categoryvalue.Status == true)
            {
                categoryvalue.Status = false;
            }
            else
            {
                categoryvalue.Status = true;
            }
            cm.CategoryUpdate(categoryvalue);
            return RedirectToAction("Index");
        }
    }
}