using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBC.ViewModel;
using XBD.DataModel;

namespace XBC.Repo
{
    public class MenuAcsesRepo
    {
        public static List<MenuAccessViewModel> All(int id = 0)
        {
            List<MenuAccessViewModel> result = new List<MenuAccessViewModel>();
            using (var db = new XBCContext())
            {

                result = (from ma in db.t_menu_access
                          join m in db.t_menu on
                          ma.menu_id equals m.id
                          join r in db.t_role on
                          ma.role_id equals r.id
                          where ma.role_id == (id == 0 ? ma.role_id : id)
                          select new MenuAccessViewModel
                          {
                              id = ma.id,
                              menu_id = ma.menu_id,
                              title = m.title,
                              role_id = ma.role_id,
                              role = r.name
                          }

                          ).ToList();

            }
            return result;
        }
        public static List<MenuAccessViewModel> AllByRole(int id)
        {
            List<MenuAccessViewModel> result = new List<MenuAccessViewModel>();
            using (var db = new XBCContext())
            {

            }
            return result;
        }
        public static MenuAccessViewModel GetById(int id)
        {
            MenuAccessViewModel result = new MenuAccessViewModel();
            using (var db = new XBCContext())
            {
                result = (from ma in db.t_menu_access
                          join m in db.t_menu on ma.menu_id equals m.id
                          join r in db.t_role on ma.role_id equals r.id
                          where ma.id == id
                          select new MenuAccessViewModel
                          {
                              id = ma.id,
                              menu_id = ma.menu_id,
                              title = m.title,
                              role_id = ma.role_id,
                              role = r.name
                          }
                           ).FirstOrDefault();
            }
            return result;
        }
        public static ResponResultViewModel Create(MenuAccessViewModel entity, long userid)
        {
            //untuk create dan edit
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new XBCContext())
                {
                    var cek = (from r in db.t_menu_access
                               where r.role_id.Equals(entity.role_id) && r.menu_id.Equals(entity.menu_id)
                               select new MenuAccessViewModel
                               {
                                   role_id = r.role_id,
                                   menu_id = r.menu_id
                               }).FirstOrDefault();

                    var rsl = cek;

                    //if (entity.role_id.Equals(null) && entity.menu_id.Equals(null))
                    if(rsl== null)
                    {
                        t_menu_access ma = new t_menu_access();
                        ma.id = entity.id;
                        ma.menu_id = entity.menu_id;
                        ma.role_id = entity.role_id;

                        ma.created_by = userid;
                        ma.created_on = DateTime.Now;

                        db.t_menu_access.Add(ma);
                        db.SaveChanges();

                        result.Entity = entity;
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "Kemungkinan Terdapat data ganda";
                    }
                   
                    // }
                    //else
                    //{
                    //    t_menu_access ma = db.t_menu_access.Where(o => o.id == entity.id).FirstOrDefault();
                    //    if (ma != null)
                    //    {
                    //        ma.menu_id = entity.menu_id;
                    //        ma.role_id = entity.role_id;


                    //    }
                    //}
                }
            }
            catch (Exception e)
            {

                result.Success = false;
                result.Message = e.Message;
            }
            return result;
        }

        public static List<MenuAccessViewModel> GetByRoleId(int id)
        {
            List<MenuAccessViewModel> result = new List<MenuAccessViewModel>();
            using (var db = new XBCContext())
            {
                result = (from ma in db.t_menu_access
                          join r in db.t_role on ma.role_id equals r.id
                          join m in db.t_menu on ma.menu_id equals m.id
                          where ma.role_id == id
                          select new MenuAccessViewModel
                          {
                              id = ma.id,
                              menu_id = ma.menu_id,
                              title = m.title,
                              role_id = ma.role_id,
                              role = r.name

                          }).ToList();
            }
            return result;
        }
        public static List<MenuAccessViewModel> search(long? key)
        {
            List<MenuAccessViewModel> result = new List<MenuAccessViewModel>();
            using (var db = new XBCContext())
            {
                result = (from ma in db.t_menu_access
                          join r in db.t_role on
                          ma.role_id equals r.id
                          join m in db.t_menu on
                          ma.menu_id equals m.id
                          where ma.role_id == key
                          select new MenuAccessViewModel
                          {
                              id = ma.id,
                              menu_id = ma.menu_id,
                              title = m.title,
                              role_id = ma.role_id,
                              role = r.name,
                          }).ToList();
            }
            return result;
        }
        public static ResponResultViewModel Delete(MenuAccessViewModel entity)
        {
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new XBCContext())
                {
                    t_menu_access ma = db.t_menu_access.Where(o => o.id == entity.id).FirstOrDefault();
                    if (ma != null)
                    {

                        db.t_menu_access.Remove(ma);
                        db.SaveChanges();

                        result.Entity = entity;
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "Menu Access Not Found";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
