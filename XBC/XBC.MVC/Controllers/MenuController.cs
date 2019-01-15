using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XBC.Repo;
using XBC.ViewModel;

namespace XBC.MVC.WebApp.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index(string search)
        {
            return View(MenuRepo.All(search));
        }
        // List
        public ActionResult List(string search)
        {
            return PartialView("_List", MenuRepo.All(search));
        }
        //Create
        public ActionResult Create()
        {
            ViewBag.ListMenu = new SelectList(MenuRepo.All(null), "id", "title");//bekal
            return PartialView("_Create");
        }
        [HttpPost]
        public ActionResult Create(MenuViewModel model)
        {
            var userid = (long)Session["userid"];
            ViewBag.ListMenu = new SelectList(MenuRepo.All(null), "id", "title");//bekal
            ResponResultViewModel result = MenuRepo.Update(model,userid);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
        //Edit
        public ActionResult Edit(int id)
        {
            ViewBag.ListMenu = new SelectList(MenuRepo.All(null), "id", "title");//bekal
            return PartialView("_Edit", MenuRepo.GetMenu(id));
        }
        [HttpPost]
        public ActionResult Edit(MenuViewModel model)
        {
            var userid = (long)Session["userid"];
            ViewBag.ListMenu = new SelectList(MenuRepo.All(null), "id", "title");//bekal
            ResponResultViewModel result = MenuRepo.Update(model,userid);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int id)
        {
            return PartialView("_Delete", MenuRepo.GetMenu(id));
        }
        [HttpPost]
        public ActionResult Delete(MenuViewModel model)
        {
            var userid = (long)Session["userid"];
            ResponResultViewModel result = MenuRepo.Delete(model,userid);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
    }
}