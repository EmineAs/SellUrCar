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
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();

        //[Authorize]
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
                p.SenderMail = "admin@gmail.com";
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
            p.SenderMail = "admin@gmail.com";
            p.Draft = true;
            p.MessageStatus = true;
            p.MessageDate = DateTime.Now;
            messageManager.MessageAddDraftBL(p);
            return RedirectToAction("Inbox");

        }


    }
}