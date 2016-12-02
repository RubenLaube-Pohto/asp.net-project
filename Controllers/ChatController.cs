using ChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        // Main action. Returns the main chat view.
        [HttpGet]
        [Route("/chat")]
        public IActionResult Chat()
        {
            ChatMessagesViewModel messages = new ChatMessagesViewModel();
            messages.OldMessages = GetMessages();
            messages.NewMessage = new Message();

            try
            {
                messages.NewMessage.Author = HttpContext.Session.GetString("authorName");
            }
            catch (Exception e) { }

            return View("~/Views/ChatView.cshtml", messages);
        }

        // Saves a new message to the database
        // TODO: Add some error management and inform user of errors
        [HttpPost]
        [Route("/chat")]
        [ValidateAntiForgeryToken] // Prevents cross-site request forgery
        public IActionResult SendNewMessage(ChatMessagesViewModel model)
        {
            try
            {
                HttpContext.Session.SetString("authorName", model.NewMessage.Author);
            }
            catch (Exception e) { }

            // Validate input
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

        /*
         * Delete a message by id from the database
         *
         * Currently using GET. I would like to have this as DELETE or at least POST
         * but I can't get it to work in the current time frame.
         */
        // TODO: Implemet as POST or DELETE
        [Route("/chat/{id}")]
        public IActionResult DeleteMessage(int id)
        {
            using (var context = GetContext())
            {
                Message message = context.Messages.Where(m => m.Id == id).SingleOrDefault();
                context.Messages.Remove(message);
                context.SaveChanges();
            }
            return RedirectToAction("Chat");
        }

        // Get all messages from the database
        protected List<Message> GetMessages()
        {
            using (var context = GetContext())
            {
                return context.Messages.ToList();
            }
        }

        // Get database context
        protected MessagesContext GetContext()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("MySQLConnection");

            return MessagesContextFactory.Create(connectionString);
        }
    }

    /*
     * As only one type can be passed to the view, it is helpfull to
     * have a helper class for holding more than one type.
     */
    public class ChatMessagesViewModel
    {
        public IEnumerable<Message> OldMessages { get; set; }
        public Message NewMessage { get; set; }
    }
}
