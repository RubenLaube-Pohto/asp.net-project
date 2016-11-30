using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ChatApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        [Route("/chat")]
        public IActionResult Chat()
        {
            List<Message> messages = GetMessages();
            return View("~/Views/ChatView.cshtml", messages);
        }

        protected List<Message> GetMessages()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("MySQLConnection");

            using (var context = MessagesContextFactory.Create(connectionString))
            {
                return context.Messages.ToList();
            }
        }
    }
}
