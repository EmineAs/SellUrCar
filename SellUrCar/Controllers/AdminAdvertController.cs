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
    //[AllowAnonymous] //Herkesin girebileceği sayfa yoksa sayfa açılmıyor

    public class AdminAdvertController : Controller
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
        ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());


        public ActionResult AllAdvert(int page=1)
        {

            var advertvalues = advertManager.GetList().ToPagedList(page,8);
            return View(advertvalues);
        }


        public PartialViewResult ImageByAdvert(int id)
        {
            var imagevalues = imageFileManager.GetListByAdID(id);
            if (imagevalues.Count > 0)
            {
                var image = imagevalues[0].ImagePath;
                ViewBag.image = image;
            }
            return PartialView();
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