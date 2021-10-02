using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellUrCar.Controllers
{
    public class UserPanelController : Controller
    {
        UserManager userManager = new UserManager(new EfUserDal());

        UserValidator userValidator = new UserValidator();

       
        public ActionResult UserProfile()
        {
            int id = (int)Session["UserID"];
            var uservalue = userManager.GetByID(id);
            return View(uservalue);
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            int id = (int)Session["UserID"];
            var uservalue = userManager.GetByID(id);
            return View(uservalue);
        }

        [HttpPost]
        public ActionResult EditProfile(User user)
        {
            ValidationResult results = userValidator.Validate(user);
            if (results.IsValid)
            {
                userManager.UserUpdate(user);
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("UserProfile","UserPanel");
        }

        public PartialViewResult UserPasswordChange(User user, string currentPassword, string newPassword)
        {
            return PartialView();
        }

       
       
    }
}