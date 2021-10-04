using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;



namespace SellUrCar.Controllers
{
    [AllowAnonymous]

    public class DefaultController : Controller
    {

        AdvertManager advertManager = new AdvertManager(new EfAdvertDal());
        ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());
        UserManager userManager = new UserManager(new EfUserDal());

        public ActionResult Adverts(int? page)
        {
            
            var advertvalues = advertManager.GetList();
            var advertpages = advertvalues.ToPagedList(page ?? 1, 7); //? işaretleri boş gelme/boş olma durumuna karşı önlem amaçlı,kacinci sayfadan baslasin, sayfada kac deger olsun anlamina gelmektedir.
            return View(advertpages);
        }

        public ActionResult AdvertsByBrand(int id)
        {
            var advertvalues = advertManager.GetListByBrand(id);
            return View(advertvalues);
        }

        public PartialViewResult MenuPartial()
        {
            var advertvalues = advertManager.GetList();
            return PartialView(advertvalues);
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

        public PartialViewResult Gallery(int id)
        {
            var imagevalues = imageFileManager.GetListByAdID(id);
            return PartialView(imagevalues);
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

    }
}