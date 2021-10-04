using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellUrCar.Controllers
{
    public class AuthorizationController : Controller
    {

        AdminManager adminManager = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var adminvalues = adminManager.GetList();
            return View(adminvalues);
        }

        public ActionResult DeleteAdmin(int id)
        {
            var adminvalue = adminManager.GetByID(id);
            adminManager.AdminDelete(adminvalue);
            return RedirectToAction("Index");
        }
    }
}