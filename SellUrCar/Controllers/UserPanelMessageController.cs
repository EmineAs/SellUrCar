using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellUrCar.Controllers
{
    public class UserPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        UserManager userManager = new UserManager(new EfUserDal());

        MessageValidator messagevalidator = new MessageValidator();


        public ActionResult Inbox()
        {
            string mail = (string)Session["UserMail"];

            var messageList = messageManager.GetListInBox(mail);
            return View(messageList);
        }

        public ActionResult ReadMessages()
        {
            string mail = (string)Session["UserMail"];

            var messageList = messageManager.GetListReadMessages(mail);
            return View("Inbox", messageList);
        }

        public ActionResult UnReadMessages()
        {
            string mail = (string)Session["UserMail"];

            var messageList = messageManager.GetListUnReadMessages(mail);
            return View("Inbox", messageList);
        }

        public ActionResult Sendbox()
        {
            string mail = (string)Session["UserMail"];

            var messageList = messageManager.GetListSendBox(mail);
            return View(messageList);
        }

        public ActionResult Draftbox()
        {
            string mail = (string)Session["UserMail"];

            var messageList = messageManager.GetListDraftBox(mail);
            return View(messageList);
        }

        public ActionResult Trashbox()
        {
            string mail = (string)Session["UserMail"];

            var messageList = messageManager.GetListTrashBox(mail);
            return View(messageList);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)] //content açılmıyordu ekledim sonra buraya dönecem

        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messagevalidator.Validate(p);

            if (results.IsValid)
            {
                p.SenderMail =(string)Session["UserMail"];
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.MessageStatus = true;
                p.Read = false;
                messageManager.MessageAddBL(p);
                return RedirectToAction("Sendbox");

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

        [HttpGet]
        public ActionResult SendMessage(int id)
        {
            var uservalues = userManager.GetByID(id);
            var mail = uservalues.UserMail;
            ViewBag.mail = mail;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)] //content açılmıyordu ekledim sonra buraya dönecem

        public ActionResult SendMessage(Message p)
        {
            ValidationResult results = messagevalidator.Validate(p);

            if (results.IsValid)
            {
                p.SenderMail = (string)Session["UserMail"];
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.MessageStatus = true;
                p.Read = false;
                messageManager.MessageAddBL(p);
                return RedirectToAction("Sendbox");

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

        public ActionResult GetMessageDetail(int id)
        {
            var messagevalue = messageManager.GetByID(id);
            messagevalue.Read = true;
            messageManager.MessageUpdate(messagevalue);
            return View(messagevalue);
        }
        public ActionResult AddDraftMessage(Message p)
        {
            p.Draft = true;
            messageManager.MessageAddDraftBL(p);
            return RedirectToAction("Inbox");

        }

        public PartialViewResult MessagePartial()
        {
            string mail = (string)Session["UserMail"];

            var inboxvalues = messageManager.GetListInBox(mail);
            var countInbox = inboxvalues.Count();
            ViewBag.countInbox = countInbox;

            var readvalues = messageManager.GetListReadMessages(mail);
            var countRead = readvalues.Count();
            ViewBag.countRead = countRead;

            var unreadvalues = messageManager.GetListUnReadMessages(mail);
            var countUnRead = unreadvalues.Count();
            ViewBag.countUnRead = countUnRead;

            var sendboxvalues = messageManager.GetListSendBox(mail);
            var countSendbox = sendboxvalues.Count();
            ViewBag.countSendbox = countSendbox;

            var draftboxvalues = messageManager.GetListDraftBox(mail);
            var countDraftbox = draftboxvalues.Count();
            ViewBag.countDraftbox = countDraftbox;

            var trashboxvalues = messageManager.GetListTrashBox(mail);
            var countTrashbox = trashboxvalues.Count();
            ViewBag.countTrashbox = countTrashbox;

            return PartialView();
        }


    }
}