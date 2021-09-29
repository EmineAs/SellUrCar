﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellUrCar.Controllers
{
    public class UserPanelContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());

        public ActionResult Index()
        {
            var contactvalues = contactManager.GetList();
            return View(contactvalues);
        }


        public ActionResult GetContactDetail(int id)
        {
            var contactvalue = contactManager.GetByID(id);
            return View(contactvalue);
        }


        public PartialViewResult ContactPartial()
        {
            var contactvalues = contactManager.GetList();
            var countContact = contactvalues.Count();
            ViewBag.countContact = countContact;

            var inboxvalues = messageManager.GetListInBox();
            var countInbox = inboxvalues.Count();
            ViewBag.countInbox = countInbox;

            var readvalues = messageManager.GetListReadMessages();
            var countRead = readvalues.Count();
            ViewBag.countRead = countRead;

            var unreadvalues = messageManager.GetListUnReadMessages();
            var countUnRead = unreadvalues.Count();
            ViewBag.countUnRead = countUnRead;

            var sendboxvalues = messageManager.GetListSendBox();
            var countSendbox = sendboxvalues.Count();
            ViewBag.countSendbox = countSendbox;

            var draftboxvalues = messageManager.GetListDraftBox();
            var countDraftbox = draftboxvalues.Count();
            ViewBag.countDraftbox = countDraftbox;

            var trashboxvalues = messageManager.GetListTrashBox();
            var countTrashbox = trashboxvalues.Count();
            ViewBag.countTrashbox = countTrashbox;

            return PartialView();
        }
    }
}