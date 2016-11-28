using System;

namespace ChatApp.Models {
    public class Message {
        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
