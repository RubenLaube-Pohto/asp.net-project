using ChatApp.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace ChatApp.Controllers
{
    public static class DatabaseConnection
    {
        public static Message SaveMessage(string author, string text)
        {
            Message message = new Message();
            using (var context = GetContext())
            {
                message.Author = author;
                message.Text = text;
                message.Timestamp = DateTime.Now;
                context.Messages.Add(message);
                context.SaveChanges();
            }
            return message;
        }

        public static void DeleteMessage(int id)
        {
            using (var context = GetContext())
            {
                Message message = context.Messages.Where(m => m.Id == id).SingleOrDefault();
                context.Messages.Remove(message);
                context.SaveChanges();
            }
        }

        public static MessagesContext GetContext()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("MySQLConnection");

            return MessagesContextFactory.Create(connectionString);
        }
    }
}