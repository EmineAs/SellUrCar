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
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddSerial(Serial p)
        {
            SerialValidator serialValidator = new SerialValidator();
            ValidationResult results = serialValidator.Validate(p);
            if (results.IsValid)
            {
                serialManager.SerialAddBL(p);
                return RedirectToAction("SerialByModel", new { @id = p.ModelID });

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
            var id2 = serialvalue.ModelID;
            serialManager.SerialDelete(serialvalue);
            return RedirectToAction("SerialByModel", new { @id = id2 });
        }

        public ActionResult EditSerial(Serial p)
        {
            serialManager.SerialUpdate(p);
            return RedirectToAction("SerialByModel", new { @id = p.ModelID });
        }


        public PartialViewResult AddSerialPartial(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }

        public PartialViewResult EditSerialPartial(int id)
        {
            var serialvalue = serialManager.GetByID(id);
            ViewBag.modelid = serialvalue.ModelID;
            serialManager.SerialUpdate(serialvalue);
            return PartialView(serialvalue);
        }

        public ActionResult SerialByModel(int id)
        {
            var serialvalues = serialManager.GetListByModelID(id);
            ViewBag.id = id;
            return View(serialvalues);
        }
    }
}