using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SellUrCar.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        AdminManager adminManager = new AdminManager(new EfAdminDal());


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DeleteAdmin(Admin admin)
        {
            adminManager.AdminDelete(admin);
            return RedirectToAction("Index");
        }

        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            AdminValidator adminValidator = new AdminValidator();
            ValidationResult results = adminValidator.Validate(p);
            if (results.IsValid)
            {
                adminManager.AdminAddBL(p);
                return RedirectToAction("Index", "Authorization");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}