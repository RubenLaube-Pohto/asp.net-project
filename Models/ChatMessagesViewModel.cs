using System.Collections.Generic;

/*
* As only one type can be passed to the view, it is helpfull to
* have a helper class for holding more than one type.
*/
namespace ChatApp.Models
{
    public class ChatMessagesViewModel
    {
        public IEnumerable<Message> OldMessages { get; set; }
        public Message NewMessage { get; set; }
    }
}
