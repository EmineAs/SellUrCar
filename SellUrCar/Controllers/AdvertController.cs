using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using PagedList.Mvc;

namespace MvcProjeKampi.Controllers
{

    public class AdvertController : Controller
    {

        AdvertManager advertManager = new AdvertManager(new EfAdvertDal());
        BrandManager brandManager = new BrandManager(new EfBrandDal());
        FuelManager fuelManager = new FuelManager(new EfFuelDal());
        GearManager gearManager = new GearManager(new EfGearDal());
        CityManager cityManager = new CityManager(new EfCityDal());
        ColorManager colorManager = new ColorManager(new EfColorDal());
        ModelManager modelManager = new ModelManager(new EfModelDal());
        SerialManager serialManager = new SerialManager(new EfSerialDal());
        DistrictManager districtManager = new DistrictManager(new EfDistrictDal());

        [HttpGet]
        public ActionResult AddAdvert()
        {
            List<SelectListItem> valueBrand = (from x in brandManager.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.BrandName,
                                                   Value = x.BrandID.ToString()
                                               }).ToList();


            List<SelectListItem> valueFuel = (from x in fuelManager.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.FuelType,
                                                  Value = x.FuelID.ToString()
                                              }).ToList();

            List<SelectListItem> valueGear = (from x in gearManager.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.GearType,
                                                  Value = x.GearID.ToString()
                                              }).ToList();

            List<SelectListItem> valueCity = (from x in cityManager.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.CityName,
                                                  Value = x.CityID.ToString()
                                              }).ToList();

            List<SelectListItem> valueColor = (from x in colorManager.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.ColorName,
                                                   Value = x.ColorID.ToString()
                                               }).ToList();


            ViewBag.color = valueColor;
            ViewBag.brand = valueBrand;
            ViewBag.fuel = valueFuel;
            ViewBag.gear = valueGear;
            ViewBag.city = valueCity;

            return View();
        }

        [HttpPost]
        public ActionResult AddAdvert(Advert p)
        {
            p.AdvertDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            advertManager.AdvertAddBL(p);
            return RedirectToAction("Index");
        }
        public ActionResult AllAdvert(int page=1)
        {

            var advertvalues = advertManager.GetList().ToPagedList(page, 10); 
            return View(advertvalues);
        }

       
        public ActionResult ContentByAdvert()
        {
            return View();
        }

        public JsonResult GetModel(int? id)
        {

            List<SelectListItem> valueModel = (from x in modelManager.GetList()
                                               where x.SerialID == id
                                               select new SelectListItem
                                               {
                                                   Text = x.ModelName,
                                                   Value = x.ModelID.ToString()
                                               }).ToList();

            return Json(valueModel, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetSerial(int? id)
        {

            List<SelectListItem> valueSerial = (from x in serialManager.GetList()
                                                where x.BrandID == id
                                                select new SelectListItem
                                                {
                                                    Text = x.SerialName,
                                                    Value = x.SerialID.ToString()
                                                }).ToList();

            return Json(valueSerial, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDistrict(int? id)
        {

            List<SelectListItem> valueDistrict = (from x in districtManager.GetList()
                                                where x.CityID == id
                                                select new SelectListItem
                                                {
                                                    Text = x.DistrictName,
                                                    Value = x.DistrictID.ToString()
                                                }).ToList();

            return Json(valueDistrict, JsonRequestBehavior.AllowGet);
        }


    }
}