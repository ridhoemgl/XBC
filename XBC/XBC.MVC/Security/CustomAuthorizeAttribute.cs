using XBC.Repo;
using XBC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using XBC.MVC.WebApp.Security;

namespace XBC.MVC.WebApp.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        //public CustomAuthorizeAttribute()
        //{
        //    AccessRight = string.Empty;
        //}

        //public string AccessRight { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(SessionPersister.UserName))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Index" }));
            }
            else
            {
                AccountViewModel avm = new AccountViewModel();
                avm.username = SessionPersister.UserName;
                CustomPrincipal mp = new CustomPrincipal(avm.find(SessionPersister.UserName));
                if (!mp.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new { controller = "AccessDenied", action = "Index" }));
                }
            }
        }
    }
}