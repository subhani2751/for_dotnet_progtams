using Ajax_First_pro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Ajax_First_pro.Controllers
{
    public class SubhaniController : Controller
    {
        DAL.DBlayar db = new DAL.DBlayar();
        public ActionResult Index()
        {
            return View();         
        }
        public JsonResult Add(ModelLayar modelLayarl=null)
        {
            return Json(db.Save(modelLayarl),JsonRequestBehavior.AllowGet);
        }
        public JsonResult AllData()
        {
            return Json(db.All(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Edit(int id = 0)
        {
            return Json(db.Search(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delele(int id = 0)
        {
            return Json(db.Delete(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult update(ModelLayar modelLayarl=null)
        {
            return Json(db.Update(modelLayarl), JsonRequestBehavior.AllowGet);
        }

    }
}