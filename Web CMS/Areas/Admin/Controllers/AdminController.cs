using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web_CMS.HelperClass;

namespace Web_CMS.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Registration(EntityCms.User objNewUser, int Role)
        {
            try
            {
                using (var context = new EntityCms.Context.CmsDbContext())
                {
                    var chkUser = (from s in context.ObjRegisterUser where s.UserName == objNewUser.UserName || s.EmailId == objNewUser.EmailId select s).FirstOrDefault();
                    if (chkUser == null)
                    {
                        var keyNew = Helper.GeneratePassword(10);
                        var password = Helper.EncodePassword(objNewUser.Password, keyNew);
                        var existingRole = context.ObjRoles.Single(x => x.RoleId == Role);

                        objNewUser.Password = password;
                        objNewUser.VCode = keyNew;
                        objNewUser.Roles = new List<EntityCms.Role>();
                        objNewUser.Roles.Add(existingRole);
                        context.ObjRegisterUser.Add(objNewUser);
                        context.SaveChanges();
                        ModelState.Clear();
                        return RedirectToAction("LogIn", "Login");
                    }
                    ViewBag.ErrorMessage = "User Allredy Exixts!!!!!!!!!!";
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "Some exception occured" + e;
                return View();
            }
        }
       
    }
}