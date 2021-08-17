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
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var writers = wm.GetList();
            return View(writers);
        }
        [HttpGet]
        public ActionResult WriterAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterAdd(Writer p)
        {
            p.Status = true;
            wm.WriterAdd(p);
            return RedirectToAction("Index");
        }
        public PartialViewResult WriterAddMenu()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult WriterUpdate(int id)
        {
            var writervalue = wm.GetByID(id);
            return View(writervalue);
        }

        [HttpPost]
        public ActionResult WriterUpdate(Writer p)
        {
            wm.WriterUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult ActiveOrPassive(int id)
        {
            var writervalue = wm.GetByID(id);

            if (writervalue.Status == true)
            {
                writervalue.Status = false;
            }
            else
            {
                writervalue.Status = true;
            }
            wm.WriterUpdate(writervalue);
            return RedirectToAction("Index");
        }
    }
}