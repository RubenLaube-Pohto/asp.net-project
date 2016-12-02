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

    // Message model
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Author { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
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
