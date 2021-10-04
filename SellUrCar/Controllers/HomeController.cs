using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        ContactManager contactManager = new ContactManager(new EfContactDal());

        public ActionResult HomePage()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contact p)
        {

            p.UserMail = "admin@gmail.com";
            p.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.ContactStatus = true;
            contactManager.ContactAddBL(p);
            return RedirectToAction("Adverts","Default");

        }

    }
}