using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web_CMS.App_Code;
using Web_CMS.HelperClass;
using log4net;

namespace Web_CMS.Areas.Admin.Controllers {
    public class AdminController : Controller {
        static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		[CustomAuthorize(UserRoles = new Roles[] { Roles.Admin })]
        public ActionResult Registration() { return View(); }

		[CustomAuthorize(UserRoles = new Roles[] { Roles.Admin })]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Registration(EntityCms.User objNewUser, int Role) {
            try {
                using (var context = new EntityCms.Context.CmsDbContext()) {
                    var chkUser = (from s in context.ObjRegisterUser where s.UserName == objNewUser.UserName || s.EmailId == objNewUser.EmailId select s).FirstOrDefault();
                    if (chkUser == null) {
                        var keyNew = Helper.GeneratePassword(10);
                        var password = Helper.EncodePassword(objNewUser.Password, keyNew);
                        var existingRole = context.ObjRoles.Single(x => x.RoleId == Role);

                        objNewUser.Password = password;
                        objNewUser.VCode = keyNew;
						objNewUser.Roles = new List<EntityCms.Role> { existingRole };
						context.ObjRegisterUser.Add(objNewUser);
                        context.SaveChanges();
                        ModelState.Clear();
                        log.Info("User succesfully registered.");
                        return RedirectToAction("LogIn", "Login");
                    }
                    ViewBag.ErrorMessage = "User Already Exists!";
                    return View();
                }
            } catch (Exception e) {
                ViewBag.ErrorMessage = "Some exception occured" + e;
                return View();
            }
        }
    }
}