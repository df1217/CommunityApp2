using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedoCommunityApp.Repositories;
using RedoCommunityApp.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RedoCommunityApp.Controllers
{
    public class ReplyController : Controller
    {
        private IMessageRepository messageRepo;

        public ReplyController(IMessageRepository repo)
        {
            messageRepo = repo;
        }
        // GET: /<controller>/
        [HttpGet]
        public ViewResult ReplyForm( int id)
        {
            var replyVm = new ReplyViewModel();
            replyVm.MessageID = id;
            replyVm.MessageReply = new Reply();
            

            return View(replyVm);
        }
        [HttpPost]
        public IActionResult ReplyForm(int id,  string body)
        {
            // Get the full model object for the book being reviewed
            Message message = (from m in messageRepo.GetAllMessages()
                         where m.MessageID == id
                         select m).FirstOrDefault<Message>();

            // add the review and save the book object to the db
            message.Replies.Add(new Reply { Body = body});
            messageRepo.Update(message);

            return RedirectToAction("Index", "Message");
        }
    }
}
