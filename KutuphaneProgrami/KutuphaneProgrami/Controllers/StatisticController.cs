using BusinessLayer.Concrete;
using DataAccesLayer;
using DataAccesLayer.EntityFramework;
using KutuphaneProgrami.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneProgrami.Controllers
{
    [Authorize(Roles = "A")]
    public class StatisticController : Controller
    {
        BookManager bm = new BookManager(new EfBookDal());
        UserManager um = new UserManager(new EfUserDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        // GET: Statistic
        public ActionResult Index()
        {
            var bookcount = bm.GetList().Count(x=>x.Status==true);
            ViewBag.book = bookcount;
            var usercount = um.GetList().Count(x => x.UserStatus == true);
            ViewBag.user = usercount;
            var categorycount = cm.GetList().Count(x => x.Status == true);
            ViewBag.category = categorycount;
            var writercount = wm.GetList().Count(x => x.Status == true);
            ViewBag.writer = writercount;
            return View();
        }
        public List<CategoryChart> CategoryList()
        {
            List<CategoryChart> writerCharts = new List<CategoryChart>();
            using (var context = new Context())
            {
                writerCharts = context.Categories.Select(c => new CategoryChart
                {
                    CategoryName = c.CategoryName,
                    BookCount = c.Books.Count()
                }).ToList();
            }

            return writerCharts;
        }

        public ActionResult CategoryChar()
        {
            return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        }
    }
}