using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ChatApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        [HttpGet]
        [Route("/chat")]
        public IActionResult Chat()
        {
            ChatMessagesViewModel messages = new ChatMessagesViewModel();
            messages.OldMessages = GetMessages();
            messages.NewMessage = new Message();
            return View("~/Views/ChatView.cshtml", messages);
        }

        [HttpPost]
        [Route("/chat")]
        [ValidateAntiForgeryToken] // Prevents cross-site request forgery
        public IActionResult SendNewMessage(ChatMessagesViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var context = GetContext())
                {
                    Message message = model.NewMessage;
                    message.Timestamp = DateTime.Now;
                    context.Messages.Add(message);
                    context.SaveChanges();
                }
            }
            
            return RedirectToAction("Chat");
        }

        protected List<Message> GetMessages()
        {
            using (var context = GetContext())
            {
                return context.Messages.ToList();
            }
        }

        protected MessagesContext GetContext()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("MySQLConnection");

            return MessagesContextFactory.Create(connectionString);
        }
    }

    // As only one type can be passed to the view, it is helpfull to
    // have a helper class for holding more than one type.
    public class ChatMessagesViewModel
    {
        public IEnumerable<Message> OldMessages { get; set; }
        public Message NewMessage { get; set; }
    }
}
