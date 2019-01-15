using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBC.ViewModel;
using XBD.DataModel;


namespace XBC.Repo
{
    public static class UserRepo
    {

        
        public static List<UserViewModel> All(string searchString)
        {
            List<UserViewModel> result = new List<UserViewModel>();
            using (var db = new XBCContext())
            {
                if (String.IsNullOrEmpty(searchString))
                {
                    result = (from u in db.t_user
                              join r in db.t_role on u.role_id equals r.id
                              where u.is_delete == false
                              select new UserViewModel
                              {
                                  id = u.id,
                                  username = u.username,
                                  password = u.password,
                                  role_id = r.id,
                                  name = r.name,
                                  mobile_flag = u.mobile_flag,
                                  mobile_token = u.mobile_token,
                                  is_delete = u.is_delete

                              }).ToList();
                }
                else
                {
                    var src = from u in db.t_user
                              join r in db.t_role on u.role_id equals r.id
                              where u.is_delete == false
                              select new UserViewModel
                              {
                                  id = u.id,
                                  username = u.username,
                                  password = u.password,
                                  role_id = r.id,
                                  name = r.name,
                                  mobile_flag = u.mobile_flag,
                                  mobile_token = u.mobile_token,
                                  is_delete = u.is_delete
                              };
                    src = src.Where(s => s.username.Contains(searchString));
                    result = src.ToList();
                }

            }
            return result;
        }
        public static UserViewModel GetUser(int id)
        {
            UserViewModel result = new UserViewModel();
            using (var db = new XBCContext())
            {
                result = (from u in db.t_user
                          join r in db.t_role on u.role_id equals r.id
                          where u.id == id
                          select new UserViewModel
                          {
                              id = u.id,
                              username = u.username,
                              password = u.password,
                              role_id = r.id,
                              mobile_flag = u.mobile_flag,
                              mobile_token = u.mobile_token,
                              is_delete = u.is_delete

                          }).FirstOrDefault();
            }
            return result;
        }
        public static UserViewModel GetById(int id)
        {
            UserViewModel result = new UserViewModel();
            using (var db = new XBCContext())
            {
                result = (from u in db.t_user
                          where u.id == id
                          select new UserViewModel
                          {
                              id=u.id,
                              username=u.username,
                              password=u.password,
                              is_delete=u.is_delete
                          }
                        ).FirstOrDefault();
            }
            return result;
        }
        public static ResponResultViewModel Update(UserViewModel entity, long userid)
        {
            //untuk create & edit
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new XBCContext())
                {
                    if (entity.id == 0)
                    {
                        t_user user = new t_user();
                        user.username = entity.username;
                        user.password = entity.password;
                        user.role_id = entity.role_id;
                        user.mobile_flag = entity.mobile_flag;
                        user.mobile_token = entity.mobile_token;
                        user.created_by = userid;
                        user.created_on = DateTime.Now;
                        user.is_delete = entity.is_delete;

                        db.t_user.Add(user);
                        db.SaveChanges();

                        result.Entity = entity;

                    }
                    else
                    {
                        t_user user = db.t_user.Where(x => x.id == entity.id).FirstOrDefault();
                        if (user != null)
                        {
                            user.username = entity.username;
                            //user.password = entity.password;
                            user.role_id = entity.role_id;
                            user.mobile_flag = entity.mobile_flag;
                            user.mobile_token = entity.mobile_token;
                            user.modified_by = userid;
                            user.modified_on = DateTime.Now;
                            user.is_delete = entity.is_delete;

                            db.SaveChanges();
                            result.Entity = entity;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = "Data kemungkinan ganda atau tidak lengkap";
            }
            return result;
        }
        public static ResponResultViewModel Update2(UserViewModel entity, long userid)
        {
            //bool result = false;
            ResponResultViewModel result = new ResponResultViewModel();
            using (var db = new XBCContext())
            {
                t_user user = db.t_user.Where(x => x.id == entity.id).FirstOrDefault();
                if (user != null)
                {
                    //t_user usr = new t_user();
                    user.password = entity.password;

                    user.modified_by = userid;
                    user.modified_on = DateTime.Now;

                    db.SaveChanges();
                    result.Entity = entity;
                }

                
            }


            return result;
        }
        public static UserViewModel CheckUser(ResetPassword model)
        {
            UserViewModel result = new UserViewModel();

            //check user ada atau tidak
            using (XBCContext db = new XBCContext())
            {
                result = (from f in db.t_user
                          where f.username == model.username
                          select new UserViewModel
                          {
                              id = f.id,
                              username = f.username,
                              password = model.password
                          }).FirstOrDefault();
            }
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }

        }

        public static ResponResultViewModel Delete(UserViewModel entity, long userid)
        {
            //untuk deactive
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new XBCContext())
                {
                    t_user user = db.t_user.Where(x => x.id == entity.id).FirstOrDefault();
                    if (user != null)
                    {
                        user.is_delete = true;
                        user.deleted_by = userid;
                        user.deleted_on = DateTime.Now;

                        db.SaveChanges();
                        result.Entity = entity;
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "user not found!";
                    }

                }
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
            }
            return result;
        }

        public static LoginViewModel LoginCheck(LoginViewModel model)
        {
            using (XBCContext db = new XBCContext())
            {
                LoginViewModel result = new LoginViewModel();

                result = (from f in db.t_user
                          where f.username == model.username && f.password == model.password
                          select new LoginViewModel
                          {
                              username = f.username,
                              password = f.password
                          }).FirstOrDefault();

                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }

        public static UserViewModel CheckUser(ForgotPasswordViewModel model)
        {
            UserViewModel result = new UserViewModel();

            //check user ada atau tidak
            using (XBCContext db = new XBCContext())
            {
                result = (from f in db.t_user
                          where f.username == model.username
                          select new UserViewModel
                          {
                              id = f.id,
                              username = f.username,
                              password = model.password
                          }).FirstOrDefault();
            }
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }

        }
        public static UserViewModel CheckUser(UserViewModel model)
        {
            UserViewModel result = new UserViewModel();

            //check user ada atau tidak
            using (XBCContext db = new XBCContext())
            {
                result = (from f in db.t_user
                          where f.username == model.username && f.is_delete == false
                          select new UserViewModel
                          {
                              id = f.id,
                              username = f.username,
                              password = model.password
                          }).FirstOrDefault();
            }
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }

        }


        public static UserViewModel GetByUsername(string username)
        {
            UserViewModel result = new UserViewModel();
            using (XBCContext db = new XBCContext())
            {
                result = (from u in db.t_user
                          join r in db.t_role on u.role_id equals r.id
                          where u.is_delete == false && u.username == username
                          select new UserViewModel
                          {
                              id = u.id,
                              username = u.username,
                              password = u.password,
                              role_id = r.id,
                              name = r.name,
                              mobile_flag = u.mobile_flag,
                              mobile_token = u.mobile_token,
                              is_delete = u.is_delete
                          }).FirstOrDefault();
            }

            return result;
        }
    }
}
