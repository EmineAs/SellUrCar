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
    [AllowAnonymous]

    public class RegisterController : Controller
    {
        UserManager userManager = new UserManager(new EfUserDal());
        UserValidator userValidator = new UserValidator();


        [HttpGet]
        public ActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserRegister(User user)
        {
            ValidationResult results = userValidator.Validate(user);

            if (results.IsValid)
            {
                user.UserStatus = true;
                user.UserImage = "/AdminLTE-3.0.4/dist/img/2.png";
                userManager.UserAddBL(user);
                return RedirectToAction("UserLogIn", "LogIn");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
    }
}