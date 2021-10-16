using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using EntityLayer.Concrete;
using System.IO;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace SellUrCar.Controllers
{
    public class UserPanelAdvertController : Controller
    {

        AdvertManager advertManager = new AdvertManager(new EfAdvertDal());
        BrandManager brandManager = new BrandManager(new EfBrandDal());
        FuelManager fuelManager = new FuelManager(new EfFuelDal());
        GearManager gearManager = new GearManager(new EfGearDal());
        CityManager cityManager = new CityManager(new EfCityDal());
        ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());
        SerialManager serialManager = new SerialManager(new EfSerialDal());
        ModelManager modelManager = new ModelManager(new EfModelDal());
        DistrictManager districtManager = new DistrictManager(new EfDistrictDal());
        UserManager userManager = new UserManager(new EfUserDal());

        AdvertValidator advertValidator = new AdvertValidator();



        public ActionResult MyAdvert(int? page) //Buradaki int? page bos gelmeye karsi önlem amaclidir
        {
            int userIdInfo = (int)Session["UserID"];
            var advertvalues = advertManager.GetListByUserID(userIdInfo).ToPagedList(page ?? 1, 7);
            return View(advertvalues);
        }

        [HttpGet]
        public ActionResult NewAdvert()
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



            ViewBag.brand = valueBrand;
            ViewBag.fuel = valueFuel;
            ViewBag.gear = valueGear;
            ViewBag.city = valueCity;

            return View();
        }

        [HttpPost]
        public ActionResult NewAdvert(Advert advert)
        {
            ValidationResult results = advertValidator.Validate(advert);


            if (results.IsValid)
            {
                advert.AdvertDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                advert.UserID = (int)Session["UserID"];
                advertManager.AdvertAddBL(advert);
                return RedirectToAction("UploadImage", new { @id = advert.AdID });
            }
            else //Dogrulama islemi gecerli degilse;
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }

        }

        [HttpGet]
        public ActionResult EditAdvert(int id)
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
            ViewBag.brand = valueBrand;
            ViewBag.fuel = valueFuel;
            ViewBag.gear = valueGear;
            ViewBag.city = valueCity;
            var advertValue = advertManager.GetByID(id);
            return View(advertValue);
        }

        [HttpPost]
        public ActionResult EditAdvert(Advert advert)
        {
            advertManager.AdvertUpdate(advert);
            return RedirectToAction("MyAdvert");
        }

        public ActionResult DeleteAdvert(int id)
        {

            var advertvalues = advertManager.GetByID(id);
            var imagevalues = imageFileManager.GetListByAdID(id);
            imageFileManager.ImageDelete(imagevalues);
            advertManager.AdvertDelete(advertvalues);
            return RedirectToAction("MyAdvert");
        }

        public ActionResult AllAdvert(int? page) //Buradaki int? page bos gelmeye karsi önlem amaclidir
        {
            var advertvalues = advertManager.GetList();
            var advertpages = advertvalues.ToPagedList(page ?? 1, 8); //? işaretleri boş gelme/boş olma durumuna karşı önlem amaçlı,kacinci sayfadan baslasin, sayfada kac deger olsun anlamina gelmektedir.
            return View(advertpages);
        }

       

        public ActionResult AdvertDetail(int id)
        {
            var advertvalues = advertManager.GetByID(id);
            ViewBag.id = id;
            return View(advertvalues);

        }

        public PartialViewResult UserContact(int id)
        {
            var uservalues = userManager.GetByID(id);
            return PartialView(uservalues);
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

        [HttpGet]
        public ActionResult UploadImage(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }

        [HttpPost]
        public ActionResult UploadImage(ImageFile image, int id, IEnumerable<HttpPostedFileBase> imagepath)
        {
            int i = 1;
            foreach (var item in imagepath)
            {
                string filename = Path.GetFileName(item.FileName);
                string path = Path.Combine(Server.MapPath("~/AdminLTE-3.0.4/imagefiles/" + filename));
                item.SaveAs(path);
                image.AdID = id;
                image.ImageName = image.AdID + "araba" + i;
                image.ImagePath = filename;
                imageFileManager.ImageAddBL(image);
                i++;
            }
            return RedirectToAction("MyAdvert");
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

        [HttpPost]
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