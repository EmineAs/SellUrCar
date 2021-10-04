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

namespace SellUrCar.Controllers
{
    //[AllowAnonymous] //Herkesin girebileceği sayfa yoksa sayfa açılmıyor

    public class AdminAdvertController : Controller
    {

        AdvertManager advertManager = new AdvertManager(new EfAdvertDal());
        UserManager userManager = new UserManager(new EfUserDal());
        BrandManager brandManager = new BrandManager(new EfBrandDal());
        FuelManager fuelManager = new FuelManager(new EfFuelDal());
        GearManager gearManager = new GearManager(new EfGearDal());
        CityManager cityManager = new CityManager(new EfCityDal());
        ModelManager modelManager = new ModelManager(new EfModelDal());
        SerialManager serialManager = new SerialManager(new EfSerialDal());
        DistrictManager districtManager = new DistrictManager(new EfDistrictDal());
        ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());


        public ActionResult AllAdvert(int page=1)
        {

            var advertvalues = advertManager.GetList().ToPagedList(page,8);
            return View(advertvalues);
        }

        public ActionResult DeleteAdvert(int id)
        {

            var advertvalues = advertManager.GetByID(id);
            var imagevalues = imageFileManager.GetListByAdID(id);
            imageFileManager.ImageDelete(imagevalues);
            advertManager.AdvertDelete(advertvalues);
            return RedirectToAction( "AllAdvert");
        }

        public ActionResult AdvertDetail(int id)
        {
            var advertvalues = advertManager.GetByID(id);
            ViewBag.id = id;
            return View(advertvalues);

        }
        public ActionResult AdvertReport()
        {
            var advertvalues = advertManager.GetList();
            return View(advertvalues);

        }

        public ActionResult UserAdvert(int? page, int id) //Buradaki int? page bos gelmeye karsi önlem amaclidir
        {
            var uservalues = userManager.GetByID(id);
            var username = uservalues.UserName + " " + uservalues.UserSurName;
            var advertvalues = advertManager.GetListByUserID(id).ToPagedList(page ?? 1, 7);
            ViewBag.username = username;
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

    }
}