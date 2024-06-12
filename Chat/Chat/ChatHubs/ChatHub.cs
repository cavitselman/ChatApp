using Microsoft.AspNetCore.SignalR;

namespace Chat.ChatHubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string userName, string Message, DateTime date)        
        => await Clients.All.SendAsync("ReceiveMessage", userName, Message, date);
        
    }
}
