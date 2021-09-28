using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellUrCar.Controllers
{
    public class UserPanelGalleryController : Controller
    {
        ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());
        public PartialViewResult Gallery(int id)
        {
            var imagevalues = imageFileManager.GetListByAdID(id);
            return PartialView(imagevalues);
        }
    }
}