using ChatApp.Controllers;
using ChatApp.Models;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace ChatApp.Hubs
{
    public class ChatHub : Hub
    {
        public static List<string> ConnectedUsers;

        public void Send(string author, string text)
        {
            Message message = DatabaseConnection.SaveMessage(author, text);
            Clients.All.messageReceived(message.Id, message.Author, message.Text, message.Timestamp.ToString());
        }

        public void Connect(string newAuthor)
        {
            if (ConnectedUsers == null)
                ConnectedUsers = new List<string>();

            ConnectedUsers.Add(newAuthor);
            Clients.Caller.getConnectedUsers(ConnectedUsers);
            Clients.Others.newUserAdded(newAuthor);
        }

        public void Delete(int id) {
            DatabaseConnection.DeleteMessage(id);
            Clients.All.messageDeleted(id);
        }
    }
}