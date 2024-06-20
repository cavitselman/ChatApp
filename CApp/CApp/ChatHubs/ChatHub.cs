using CApp.Repos;
using CAppModels;
using Microsoft.AspNetCore.SignalR;

namespace CApp.ChatHubs
{
    public class ChatHub(ChatRepo chatRepo) : Hub
    {
        public async Task SendMessage(Chat chat)
        {
            await chatRepo.SaveChatAsync(chat);
            await Clients.All.SendAsync("ReceiveMessage", chat);
        }
    }
}
