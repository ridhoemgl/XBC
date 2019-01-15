using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using XBC.MVC.WebApp.Controllers;
using XBC.MVC.WebApp.Models;
using XBC.MVC.WebApp.Security;
using XBC.Repo;
using XBC.ViewModel;
using XBD.DataModel;

namespace XBC.MVC.WebApp.Controllers
{
  // [CustomAuthorize(Roles ="admin")]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index(string search)
        {
            return View(UserRepo.All(search));
        }
        // List
        public ActionResult List(string keyword)
        {
            return PartialView("_List", UserRepo.All(keyword));
        }
        //Create
        public ActionResult Create()
        {
            ViewBag.ListRole = new SelectList(RoleRepo.All(null), "id", "name");//untuk dropdownlist
            return PartialView("_Create");
        }
        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            var userid = (long)Session["userid"];
            var username = (string)Session["username"];
            ViewBag.ListRole = new SelectList(RoleRepo.All(null), "id", "name");//untuk dropdownlist
            ResponResultViewModel result = UserRepo.Update(model,userid);
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
            ViewBag.ListRole = new SelectList(RoleRepo.All(null), "id", "name");//untuk dropdownlist
            return PartialView("_Edit", UserRepo.GetUser(id));
        }
        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
             var userid = (long)Session["userid"];
            ViewBag.ListRole = new SelectList(RoleRepo.All(null), "id", "name");//untuk dropdownlist
            ResponResultViewModel result = UserRepo.Update(model, userid);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }

        //reset
        public ActionResult Reset(int id)
        {
            UserViewModel model = UserRepo.GetById(id);
            model.password = "";
            model.ConfirmPassword = "";
            return PartialView("_Reset", model);
        }
        [HttpPost]
        public ActionResult Reset(UserViewModel model)
        {
            var userid = (long)Session["userid"];
            ResponResultViewModel result = UserRepo.Update2(model, userid);
            return Json(new {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Delete(int id)
        {
            return PartialView("_Delete", UserRepo.GetUser(id));
        }
        [HttpPost]
        //Deactive
        public ActionResult Delete(UserViewModel model)
        {
            var userid = (long)Session["userid"];
            ResponResultViewModel result = UserRepo.Delete(model, userid);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (this.Request.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(ViewModel.LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = UserRepo.LoginCheck(model);
                if (user != null)
                {
                    SignInAsync(model.username);
                    UserViewModel item = UserRepo.GetByUsername(model.username);
                    Session["userid"] = item.id;
                    Session["username"] = item.username;
                    //using (var db = new XBCContext())
                    //{
                    //    var dataMenu = (from x in db.t_menu_access
                    //                    join u in db.t_menu on x.menu_id equals u.id
                    //                    where x.role_id == item.role_id
                    //                    select new MenuDynamicVieModel()
                    //                    {
                    //                        MainMenuId = ((int)x.menu_id),
                    //                        MainMenuName = u.title
                    //                    }).ToList();
                    //    Session["MenuMaster"] = dataMenu;
                    //}
                        return RedirectToAction("Index", "Home");
                    
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Login");
                }
            }
            return PartialView(model);
        }
        
        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;

            authenticationManager.SignOut();
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return PartialView();
        }

        [HttpPost]
        [AllowAnonymous]
        //public ActionResult ForgotPassword(ViewModel.ForgotPasswordViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        kalo user ada maka update info user/ganti password
        //        var user = UserRepo.CheckUser(model);
        //        if (user != null)
        //        {
        //            if (UserRepo.Update2(user))
        //            {
        //                setelah update otomatis login
        //                SignInAsync(user.username);
        //                return RedirectToAction("Index");
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Invalid Login");
        //        }
        //    }
        //    return PartialView(model);
        //}

        private void SignInAsync(string username)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, username));
            var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignIn(id);

        }
    }
}