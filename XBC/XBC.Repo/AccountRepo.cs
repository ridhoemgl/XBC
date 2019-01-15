using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBC.ViewModel;
using XBD.DataModel;

namespace XBC.Repo
{
    public class AccountRepo
    {

        public static AccountViewModel CurrentUser;

        public static AccountViewModel GetAccountByUserNameAndPassword(string userName, string password)
        {
            AccountViewModel result = new AccountViewModel();
            try
            {
                using (var db = new XBCContext())
                {
                    result = (from u in db.t_user
                              where u.username == userName && u.password == password && u.is_delete == false
                              select new AccountViewModel
                              {
                                  id = u.id,
                                  username = u.username,
                                  password = u.password,
                                  is_delete = u.is_delete,
                                  role_id = u.role_id
                              }).FirstOrDefault();

                    CurrentUser = result != null ? result : new AccountViewModel();

                    if (result == null)
                        result = new AccountViewModel();
                }
            }
            catch (Exception ex)
            {


            }
            return result;
        }
    }
}

//public static AccountViewModel GetAccessByRole(AccountViewModel entity, string role)
//{
//    return GetAccessByRole(entity, role, "");
//}

//public static AccountViewModel GetAccessByRole(AccountViewModel entity, string role, string accessRight)
//{
//    AccountViewModel result = new AccountViewModel();
//    result = entity;
//    result.Roles = new List<string>();
//    try
//    {
//        using (var db = new XBCContext())
//        {
//            var roles = (from ua in db.t_role
//                         where ua.name == entity.role_name
                        
//                         && ua.is_delete == false
//                         select new { Role = ua.name, AccessRight = ua.code }
//                        ).ToList();
//            foreach (var r in roles)
//            {
//                entity.Roles.Add(r.Role.Trim() + (accessRight.Length > 0 ? r.AccessRight.Trim() : ""));
//            }
//        }
//    }
//    catch (Exception ex)
//    {

//        throw;
//    }
//    return result;
//}

//public static PrivilageViewModel GetAccessByRole(string userName, string controller)
//{
//    PrivilageViewModel result = new PrivilageViewModel();
//    try
//    {
//        using (var db = new XBCContext())
//        {
//            result = (from ua in db.UserAccess
//                      where ua.UserName == userName
//                      && ua.Controller == controller
//                      && ua.Active == true
//                      select new PrivilageViewModel
//                      {
//                          Controller = ua.Controller,
//                          AccessRight = ua.AccessRight
//                      }
//                        ).FirstOrDefault();
//            if (result == null)
//            {
//                result = new PrivilageViewModel();
//            }
//        }
//    }
//    catch (Exception ex)
//    {

//        throw;
//    }
//    return result;
//}

//public static List<PrivilageViewModel> GetPriviladgeByParentId(int? parentId)
//{
//    List<PrivilageViewModel> result = new List<PrivilageViewModel>();
//    try
//    {
//        using (var db = new XBCContext())
//        {
//            result = (from mc in db.MenuController
//                      where mc.ParentId == parentId
//                      select new PrivilageViewModel
//                      {
//                          Id = mc.Id,
//                          Controller = mc.Controller,
//                          Menu = mc.Menu,
//                          Icon = mc.Icon
//                      }).ToList();
//        }
//    }
//    catch (Exception ex)
//    {

//        throw;
//    }
//    return result;
//}

//public static List<PrivilageViewModel> GetPriviladgeByParentId(string userName, int? parentId)
//{
//    List<PrivilageViewModel> result = new List<PrivilageViewModel>();
//    try
//    {
//        using (var db = new XBCContext())
//        {
//            if (userName == "Admin")
//            {
//                result = (from mc in db.MenuController
//                          where mc.ParentId == parentId &&
//                          mc.Active == true
//                          select new PrivilageViewModel
//                          {
//                              Id = mc.Id,
//                              Controller = mc.Controller,
//                              Menu = mc.Menu,
//                              Icon = mc.Icon
//                          }).ToList();
//            }
//            else
//            {
//                result = (from mc in db.MenuController
//                          join ua in db.UserAccess on
//                          mc.Controller equals ua.Controller
//                          where mc.ParentId == parentId &&
//                          ua.UserName == userName &&
//                          ua.Active == true
//                          select new PrivilageViewModel
//                          {
//                              Id = mc.Id,
//                              Controller = mc.Controller,
//                              Menu = mc.Menu,
//                              Icon = mc.Icon,
//                              AccessRight = ua.AccessRight
//                          }).ToList();
//            }
//        }
//    }
//    catch (Exception ex)
//    {

//        throw;
//    }
//    return result;
//    //}
//}

//}
