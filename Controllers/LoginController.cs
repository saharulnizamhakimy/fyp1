using fyp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace fyp1.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        fyp1dbEntities db = new fyp1dbEntities();

        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Index(tb_user usermodel, string ReturnUrl)
        {
            using (fyp1dbEntities db = new fyp1dbEntities())
            {
                var obj = db.tb_user.Where(a => a.u_ID == usermodel.u_ID && a.u_pwd == usermodel.u_pwd).FirstOrDefault();

                if (obj != null)
                {
                    FormsAuthentication.SetAuthCookie(usermodel.u_ID, false);
                    Session["UserID"] = obj.u_ID.ToString();
                    Session["Username"] = obj.u_name.ToString();
                    Session["UserType"] = obj.u_type.ToString();
                    if (Session["UserType"].ToString()!="1")
                    {
                        Session["AcadProg"] = obj.u_acadProgID.ToString();
                    }
                    if (ReturnUrl != null)
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "User ID or Password is incorrect!");
                }

            }

            return View();
        }
        [Authorize]
        public ActionResult Logout()
        {
            Session.Contents.RemoveAll();
            Session.Abandon();
            Session.Clear();
            FormsAuthentication.SignOut();
            Session["UserID"] = null;
            Session["Username"] = null;
            Session["UserType"] = null;
            Session.Contents.RemoveAll();
            return RedirectToAction("Index", "Login");

        }
    }
}