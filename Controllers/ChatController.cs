using Microsoft.AspNetCore.Mvc;
using ChatApp.Models;

namespace ChatApp.Controllers {
    public class ChatController : Controller
    {
        [Route("/chat")]
        public IActionResult Chat()
        {
            Message msg = new Message {Author = "Ossi", Text = "Moi!", Timestamp = System.DateTime.Now};
            return View("~/Views/ChatView.cshtml", msg);
        }
    }
}
