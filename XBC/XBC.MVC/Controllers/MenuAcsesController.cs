using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XBC.Repo;
using XBC.ViewModel;

namespace XBC.MVC.WebApp.Controllers
{
    public class MenuAcsesController : Controller
    {
        // GET: MenuAcses
        public ActionResult Index()
        {
            ViewBag.ListRole = new SelectList(RoleRepo.All(null), "id", "name");

            return View(MenuAcsesRepo.All());
        }
        // List
        public ActionResult List(int id = 0)
        {
            return PartialView("_List", MenuAcsesRepo.All(id));
        }
        public ActionResult ListSearch(int id)
        {
            List<MenuAccessViewModel> result = MenuAcsesRepo.GetByRoleId(id);
            return PartialView("_ListSearch", result);
        }

        public ActionResult Create()
        {
            ViewBag.ListMenuTitle = new SelectList(MenuRepo.All(null), "id", "title");//untuk dropdownlist
            ViewBag.ListRole = new SelectList(RoleRepo.All(null), "id", "name");//untuk dropdownlist
            return PartialView("_Create", new MenuAccessViewModel());
        }
        [HttpPost]
        public ActionResult Create(MenuAccessViewModel model)
        {
            var userid = (long)Session["userid"];
            ViewBag.ListMenuTitle = new SelectList(MenuRepo.All(null), "id", "title");//untuk dropdownlist
            ViewBag.ListMenuRole = new SelectList(RoleRepo.All(null), "id", "role");//untuk dropdownlist
            ResponResultViewModel result = MenuAcsesRepo.Create(model,userid);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetRole()
        {
            return PartialView("_GetRole", RoleRepo.All(null));
        }
        public ActionResult search(long? key)
        {
            List<MenuAccessViewModel> result = MenuAcsesRepo.search(key);
            return PartialView("_ListSearch", result);
        }
        public ActionResult Delete(int id)
        {
            return PartialView("_Delete", MenuAcsesRepo.GetById(id));
        }
        [HttpPost]
        public ActionResult Delete(MenuAccessViewModel model)
        {
            ResponResultViewModel result = MenuAcsesRepo.Delete(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);

        }
    }
}