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
        SerialManager SerialManager = new SerialManager(new EfSerialDal());

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
                return RedirectToAction("ModelBySerial", new { @id = p.SerialID });

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return RedirectToAction("ModelBySerial");
            }
        }

        public ActionResult DeleteModel(int id)
        {
            var modelvalue = modelManager.GetByID(id);
            var id2 = modelvalue.SerialID;
            modelManager.ModelDelete(modelvalue);
            return RedirectToAction("ModelBySerial", new { @id = id2 });
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
            return RedirectToAction("ModelBySerial", new { @id = p.SerialID });
        }


        public ActionResult ModelBySerial(int id)
        {

            var modelvalues = modelManager.GetListBySerialID(id);
            var serialvalues = SerialManager.GetByID(id);
            var brandname = serialvalues.Brands.BrandName;
            var serialname = serialvalues.SerialName;
            ViewBag.brandname = brandname;
            ViewBag.serialname = serialname;
            return View(modelvalues);
        }


    }
}