using EntityCms.Context;
using System;
using System.Linq;
using System.Web.Mvc;
using Web_CMS.HelperClass;

namespace Web_CMS.Areas.Admin.Controllers {
    public class LoginController : Controller {
        // GET: Admin/Login
        public ActionResult Login() { return View(); }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult LogIn(string userName, string password) {
            try {
                using (var context = new CmsDbContext()) {
                    var getUser = (from s in context.ObjRegisterUser where s.UserName == userName || s.EmailId == userName select s).FirstOrDefault();
                    if (getUser != null) {
                        var hashCode = getUser.VCode;
                        //Password Hasing Process Call Helper Class Method
                        var encodingPasswordString = Helper.EncodePassword(password, hashCode);
                        //Check Login Detail User Name Or Password
                        var query = (from s in context.ObjRegisterUser where (s.UserName == userName || s.EmailId == userName) && s.Password.Equals(encodingPasswordString) select s).FirstOrDefault();
                        if (query != null) {
                            return RedirectToAction("Index", "Places", new { area = "Places" });
                        }
                        ViewBag.ErrorMessage = "Invalid User Name or Password";
                        return View();
                    }
                    ViewBag.ErrorMessage = "Invalid User Name or Password";
                    return View();
                }
            } catch (Exception e) {
                ViewBag.ErrorMessage = e.Message;
                return View();
            }
        }
    }
}