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
    public class AdminModelController : Controller
    {
        ModelManager modelManager = new ModelManager(new EfModelDal());
        BrandManager brandManager = new BrandManager(new EfBrandDal());

        public PartialViewResult AddModelPartial(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }

        public ActionResult AddModel(Model p)
        {
            ModellValidator modelValidator = new ModellValidator();
            ValidationResult results = modelValidator.Validate(p);
            if (results.IsValid)
            {
                modelManager.ModelAddBL(p);
                return RedirectToAction("ModelByBrand",new { @id = p.BrandID });

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return RedirectToAction("ModelByBrand");
            }
        }

        public ActionResult DeleteModel(int id)
        {
            var modelvalue = modelManager.GetByID(id);
            var id2 = modelvalue.BrandID;
            modelManager.ModelDelete(modelvalue);
            return RedirectToAction("ModelByBrand", new { @id = id2 });
        }

        [HttpGet]
        public ActionResult EditModel(int id)
        {
            var modelvalue = modelManager.GetByID(id);
            return View(modelvalue);
        }

        [HttpPost]
        public ActionResult EditModel(Model p)
        {
            modelManager.ModelUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult ModelByBrand(int id)
        {
            var modelvalues = modelManager.GetListByBrandID(id);
            var brandvalue = brandManager.GetByID(id);
            ViewBag.brand = brandvalue.BrandName;

            return View(modelvalues);
        }

        
    }
}