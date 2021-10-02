using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellUrCar.Controllers
{
    [AllowAnonymous]

    public class HomeController : Controller
    {

        AdvertManager advertManager = new AdvertManager(new EfAdvertDal());
        ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());

        public ActionResult HomePage()
        {
            return View();
        }
       
    //    public ActionResult Index(int? page) //Buradaki int? page bos gelmeye karsi önlem amaclidir
    //    {
    //        var advertvalues = advertManager.GetList();
    //        var advertpages = advertvalues.ToPagedList(page ?? 1, 8); //? işaretleri boş gelme/boş olma durumuna karşı önlem amaçlı,kacinci sayfadan baslasin, sayfada kac deger olsun anlamina gelmektedir.
    //        return View(advertpages);
    //    }

    //    public PartialViewResult ImageByAdvert(int id)
    //    {
    //        var imagevalues = imageFileManager.GetListByAdID(id);
    //        if (imagevalues.Count > 0)
    //        {
    //            var image = imagevalues[0].ImagePath;
    //            ViewBag.image = image;
    //        }
    //        return PartialView();
    //    }

    //    public ActionResult About()
    //    {
    //        ViewBag.Message = "Your application description page.";

    //        return View();
    //    }

    //    public ActionResult Contact()
    //    {
    //        ViewBag.Message = "Your contact page.";

    //        return View();
    //    }
    }
}