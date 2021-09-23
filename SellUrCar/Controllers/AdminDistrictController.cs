using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace SellUrCar.Controllers
{
    public class AdminDistrictController : Controller
    {
        DistrictManager districtManager = new DistrictManager(new EfDistrictDal());
       
        public ActionResult AddDistrict(District p)
        {
            DistrictValidator DistrictValidator = new DistrictValidator();
            ValidationResult results = DistrictValidator.Validate(p);
            if (results.IsValid)
            {
                districtManager.DistrictAddBL(p);
                return RedirectToAction("DistrictByCity", new { @id = p.CityID });

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

        public ActionResult DeleteDistrict(int id)
        {
            var districtvalue = districtManager.GetByID(id);
            var id2 = districtvalue.CityID;
            districtManager.DistrictDelete(districtvalue);
            return RedirectToAction("DistrictByCity", new { @id = id2 });
        }

        public ActionResult EditDistrict(District p)
        {
            districtManager.DistrictUpdate(p);
            return RedirectToAction("DistrictByCity", new { @id = p.CityID });
        }

        public PartialViewResult AddDistrictPartial(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }

        public PartialViewResult EditDistrictPartial(int id)
        {
            var districtvalue = districtManager.GetByID(id);
            ViewBag.Cityid = districtvalue.CityID;
            districtManager.DistrictUpdate(districtvalue);
            return PartialView(districtvalue);
        }

        public ActionResult DistrictByCity(int id)
        {
            var districtvalues = districtManager.GetListByCityID(id);
            ViewBag.id = id;
            return View(districtvalues);
        }


    }
}