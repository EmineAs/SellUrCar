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
using PagedList;
using PagedList.Mvc;

namespace SellUrCar.Controllers
{
    public class AdminBrandController : Controller
    {
        BrandManager brandManager = new BrandManager(new EfBrandDal());
       
        [Authorize(Roles = "B")]
        public ActionResult Index(int? page)
        {
            var brandvalues = brandManager.GetList().ToPagedList(page ?? 1,10);
            return View(brandvalues);
        }

        public PartialViewResult AddBrandPartial()
        {
            return PartialView();
        }

        public ActionResult AddBrand(Brand p)
        {
            BrandValidator Brandvalidator = new BrandValidator();
            ValidationResult results = Brandvalidator.Validate(p);
            if (results.IsValid)
            {
                brandManager.BrandAddBL(p);
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

        public ActionResult DeleteBrand(int id)
        {
            var brandvalue = brandManager.GetByID(id);
            brandManager.BrandDelete(brandvalue);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditBrand(int id)
        {
            var brandvalue = brandManager.GetByID(id);
            return View(brandvalue);
        }

        [HttpPost]
        public ActionResult EditBrand(Brand p)
        {
            brandManager.BrandUpdate(p);
            return RedirectToAction("Index");
        }
    }
}