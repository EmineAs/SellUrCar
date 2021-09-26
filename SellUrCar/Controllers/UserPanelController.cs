using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SellUrCar.Controllers
{
    public class UserPanelController : Controller
    {
        AdvertManager advertManager = new AdvertManager(new EfAdvertDal());
        BrandManager brandManager = new BrandManager(new EfBrandDal());
        UserManager userManager = new UserManager(new EfUserDal());
        ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());
        SerialManager serialManager = new SerialManager(new EfSerialDal());
        ModelManager modelManager = new ModelManager(new EfModelDal());
        //StatusManager statusManager = new StatusManager(new EfStatusDal());

        AdvertValidator advertValidator = new AdvertValidator();
        UserValidator userValidator = new UserValidator();

        Context c = new Context();

        [HttpGet]
        public ActionResult UserProfile(int id = 0)
        {
            string session = (string)Session["UserMail"];
            id = c.Users.Where(x => x.UserMail == session).Select(y => y.UserID).FirstOrDefault();
            var uservalue = userManager.GetByID(id);
            return View(uservalue);
        }

        [HttpPost]
        public ActionResult UserProfile(User user)
        {
            ValidationResult results = userValidator.Validate(user);
            if (results.IsValid)
            {
                user.UserStatus = true;
                userManager.UserUpdate(user);
                return RedirectToAction("AllAdverts", "UserPanel");
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


        public PartialViewResult UserPasswordChange(User user, string currentPassword, string newPassword)
        {
            return PartialView();
        }

        public ActionResult MyAdvert(int? page) //Buradaki int? page bos gelmeye karsi önlem amaclidir
        {
            string session = (string)Session["UserMail"];
            var userIdInfo = c.Users.Where(x => x.UserMail == session).Select(y => y.UserID).FirstOrDefault();
            var advertvalues = advertManager.GetListByUserID(userIdInfo).ToPagedList(page ?? 1, 8);
            return View(advertvalues);
        }

        [HttpGet]
        public ActionResult NewAdvert()
        {
            List<SelectListItem> _valueBrand = (from x in brandManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.BrandName,
                                                    Value = x.BrandID.ToString()
                                                }).ToList();
            ViewBag.valueBrand = _valueBrand;
            return View();
        }

        [HttpPost]
        public ActionResult NewAdvert(Advert advert)
        {
            ValidationResult results = advertValidator.Validate(advert);

            string UserMailInfo = (string)Session["UserMail"];
            var UserIdInfo = c.Users.Where(x => x.UserMail == UserMailInfo)
                .Select(y => y.UserID).FirstOrDefault();

            advert.AdvertDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            advert.BrandID = UserIdInfo;
           /* Advert.StatusId = 2;*/ // Yazar yeni baslik eklediginde baslangic degeri aktif olarak gelecek
            //Advert.AdvertStatus = true; 

            advert.UserID = UserIdInfo;
            //AdvertManager.AdvertAdd(Advert);
            //return RedirectToAction("MyAdvert");

            if (results.IsValid)
            {
                advertManager.AdvertAddBL(advert);
                return RedirectToAction("MyAdvert");
            }
            else //Dogrulama islemi gecerli degilse;
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditAdvert(int id)
        {
            List<SelectListItem> _valueBrand = (from x in brandManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.BrandName,
                                                    Value = x.BrandID.ToString()
                                                }).ToList();

            //List<SelectListItem> UserStatusValue = (from x in statusManager.GetList()
            //                                        select new SelectListItem
            //                                        {
            //                                            Text = x.StatusName,
            //                                            Value = x.StatusId.ToString()
            //                                        }).ToList();

            //ViewBag.valueUserStatus = UserStatusValue;



            ViewBag.valueBrand = _valueBrand;
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
            var advertValue = advertManager.GetByID(id);

            //if (AdvertValue.StatusId == 2) // Durumu Aktif mi?
            //{
            //    AdvertValue.StatusId = 1; // Durumu pasif yap
            //}
            //else
            //{
            //    AdvertValue.StatusId = 2; // Durumu aktif yap
            //}

            advertManager.AdvertDelete(advertValue);
            return RedirectToAction("MyAdvert");

        }

        public ActionResult AllAdvert(int? page) //Buradaki int? page bos gelmeye karsi önlem amaclidir
        {
            
            var advertvalues = advertManager.GetList();
            var advertpages=advertvalues.ToPagedList( page ?? 1, 8); //? işaretleri boş gelme/boş olma durumuna karşı önlem amaçlı,kacinci sayfadan baslasin, sayfada kac deger olsun anlamina gelmektedir.
            
            return View(advertpages);
        }

        public PartialViewResult ImageByAdvert(int id)
        {
            var imagevalues = imageFileManager.GetListByAdID(id);
            var image = imagevalues[0].ImagePath;
            ViewBag.image = image;
            return PartialView();
        }
    }
}