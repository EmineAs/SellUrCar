using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellUrCar.Controllers
{
    public class AdminUserController : Controller
    {
        UserManager userManager = new UserManager(new EfUserDal());
        UserValidator userValidator = new UserValidator();
        public ActionResult Index()
        {
            var uservalues = userManager.GetListActive();
            return View(uservalues);
        }

        public ActionResult PassiveUser()
        {
            var uservalues = userManager.GetListPassive();
            return View(uservalues);
        }

        public ActionResult DoActive(int id)
        {
            var uservalue = userManager.GetByID(id);
            uservalue.UserStatus = true;
            userManager.UserUpdate(uservalue);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteUser(int id)
        {
            var uservalue = userManager.GetByID(id);
            uservalue.UserStatus = false;
            userManager.UserUpdate(uservalue);
            return RedirectToAction("Index");
        }


    }
}