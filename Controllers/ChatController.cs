using Microsoft.AspNetCore.Mvc;
using ChatApp.Models;
using System.Collections.Generic;

namespace ChatApp.Controllers {

    public class ChatController : Controller
    {
        [Route("/chat")]
        public IActionResult Chat()
        {
            List<Message> messages = GetMessages();
            return View("~/Views/ChatView.cshtml", messages);
        }

        protected List<Message> GetMessages() {
            // TODO: Get messages from a MySQL database
            List<Message> messages = new List<Message> {
                new Message { Author = "Ossi", Text = "Moi!", Timestamp = System.DateTime.Now },
                new Message { Author = "Make", Text = "Miten menee?", Timestamp = System.DateTime.Now }
            };
            return messages;
        }
    }
}
