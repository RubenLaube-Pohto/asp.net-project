using Microsoft.EntityFrameworkCore;
using System;

namespace ChatApp.Models
{
    public class MessagesContext : DbContext
    {
        public MessagesContext(DbContextOptions<MessagesContext> options) : base(options) { }

        public DbSet<Message> Messages { get; set; }
    }

    public static class MessagesContextFactory
    {
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
        public int Id { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
