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
    public class AdminCityController : Controller
    {
        CityManager cityManager = new CityManager(new EfCityDal());
        public ActionResult Index()
        {
            var Cityvalues = cityManager.GetList();
            return View(Cityvalues);
        }


        public ActionResult AddCity(City p)
        {
            CityValidator Cityvalidator = new CityValidator();
            ValidationResult results = Cityvalidator.Validate(p);
            if (results.IsValid)
            {
                cityManager.CityAddBL(p);
                return RedirectToAction("Index");
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

        public ActionResult DeleteCity(int id)
        {
            var cityvalue = cityManager.GetByID(id);
            cityManager.CityDelete(cityvalue);
            return RedirectToAction("Index");
        }

        public ActionResult EditCity(City p)
        {
            cityManager.CityUpdate(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AddCityPartial()
        {
            return PartialView();
        }

        public PartialViewResult EditCityPartial(int id)
        {
            var cityvalue = cityManager.GetByID(id);
            cityManager.CityUpdate(cityvalue);
            return PartialView(cityvalue);
        }
    }
}