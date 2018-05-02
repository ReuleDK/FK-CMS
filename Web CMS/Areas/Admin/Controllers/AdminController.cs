using EntityCms;
using System;
using System.Linq;
using System.Web.Mvc;
using Web_CMS.HelperClass;

namespace Web_CMS.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
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
        public ActionResult Registration(User objNewUser)
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
                        objNewUser.Password = password;
                        objNewUser.VCode = keyNew;
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