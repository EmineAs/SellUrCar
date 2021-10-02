using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SellUrCar.Controllers
{
    [AllowAnonymous] //Herkesin girebileceği sayfa yoksa sayfa açılmıyor
    public class LoginController : Controller
    {
        Context c = new Context();
        UserManager usermanager = new UserManager(new EfUserDal());

        // GET: Login
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminMail == p.AdminMail && x.AdminPassword == p.AdminPassword);
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminMail, false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                return RedirectToAction("AllAdvert", "AdminAdvert");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult UserLogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogIn(User user)
        {
            var userinfo = c.Users.FirstOrDefault(x => x.UserMail == user.UserMail && x.UserPassWord == user.UserPassWord && x.UserStatus ==true);
            if (userinfo != null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.UserName, false);
                Session["UserID"] = userinfo.UserID;
                Session["UserMail"] = userinfo.UserMail;
                Session["UserName"] = userinfo.UserName;
                Session["UserSurName"] = userinfo.UserSurName;
                Session["UserImage"] = userinfo.UserImage;
                return RedirectToAction("AllAdvert", "UserPanelAdvert");
            }
            else
            {
                return View();
            }
        }
    }
}