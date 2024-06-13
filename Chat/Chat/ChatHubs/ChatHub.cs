using Microsoft.AspNetCore.SignalR;
namespace Chat.ChatHubs    
{
    using ChatModels;
    public class ChatHub : Hub
    {
        public async Task SendMessage(Chat chat)        
        => await Clients.All.SendAsync("ReceiveMessage", chat);        
    }
}
