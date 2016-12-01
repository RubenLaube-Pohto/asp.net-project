using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace ChatApp.Models
{
    public class MessagesContext : DbContext
    {
        public MessagesContext(DbContextOptions<MessagesContext> options) : base(options) { }

        public DbSet<Message> Messages { get; set; }
    }

    public static class MessagesContextFactory
    {
        // Crete new context. Also initializes the database if it doesn't exist.
        public static MessagesContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MessagesContext>();
            optionsBuilder.UseMySql(connectionString);
            var context = new MessagesContext(optionsBuilder.Options);

            // Usefull for database creation when it doesn't exist yet.
            context.Database.EnsureCreated();

            return context;
        }
    }

    // TODO: Add some controls on datatype with regards to databse.
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [RequiredAttribute]
        public string Author { get; set; }
        [RequiredAttribute]
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }

        public Message()
        {
            this.Author = string.Empty;
            this.Text = string.Empty;
        }

        public Message(string author, string text, DateTime timestamp)
        {
            this.Author = author;
            this.Text = text;
            this.Timestamp = timestamp;
        }
    }
}
