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
    public class AdminSerialController : Controller
    {
        SerialManager serialManager = new SerialManager(new EfSerialDal());
        BrandManager brandManager = new BrandManager(new EfBrandDal());
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult AddSerialPartial(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddSerial(Serial p)
        {
            SerialValidator serialValidator = new SerialValidator();
            ValidationResult results = serialValidator.Validate(p);
            if (results.IsValid)
            {
                serialManager.SerialAddBL(p);
                return RedirectToAction("SerialByBrand", new { @id = p.BrandID });

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

        public ActionResult DeleteSerial(int id)
        {
            var serialvalue = serialManager.GetByID(id);
            var id2 = serialvalue.BrandID;
            serialManager.SerialDelete(serialvalue);
            return RedirectToAction("SerialByBrand", new { @id = id2 });
        }

        [HttpGet]
        public ActionResult EditSerial(int id)
        {
            var serialvalue = serialManager.GetByID(id);
            return View(serialvalue);
        }

        [HttpPost]
        public ActionResult EditSerial(Serial p)
        {
            serialManager.SerialUpdate(p);
            return RedirectToAction("SerialByBrand", new { @id = p.BrandID });
        }

        public ActionResult SerialByBrand(int id)
        {
            var serialvalues = serialManager.GetListByBrandID(id);
            var brandvalues = brandManager.GetByID(id);
            ViewBag.brandname = brandvalues.BrandName;
            return View(serialvalues);
        }
    }
}