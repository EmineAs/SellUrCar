using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MvcProjeKampi.Controllers
{
    public class AdminAdvertController : Controller
    {
        // GET: Advert

        AdvertManager advertManager = new AdvertManager(new EfAdvertDal());
        BrandManager brandManager = new BrandManager(new EfBrandDal());
        UserManager userManager = new UserManager(new EfUserDal());
        

        public ActionResult Index()
        {
            var advertvalues = advertManager.GetList();
            return View(advertvalues);
        }

        [HttpGet]
        public ActionResult AddAdvert()
        {
            List<SelectListItem> valueBrand = (from x in brandManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.BrandName,
                                                      Value = x.BrandID.ToString()
                                                  }).ToList();

            List<SelectListItem> valueUser = (from x in userManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.UserName + " " + x.UserSurName,
                                                    Value = x.UserID.ToString()
                                                }).ToList();

            ViewBag.vlb = valueBrand;
            ViewBag.vlu = valueUser;
            return View();
        }

        [HttpPost]
        public ActionResult AddAdvert(Advert p)
        {
            p.AdvertDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            advertManager.AdvertAddBL(p);
            return RedirectToAction("Index");
        }

        public ActionResult ContentByAdvert()
        {
            return View();
        }
    }
}