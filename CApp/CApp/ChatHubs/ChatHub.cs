using CApp.Repos;
using CAppModels.DTOs;
using CAppModels.Models;
using Microsoft.AspNetCore.SignalR;

namespace CApp.ChatHubs
{
    public class ChatHub(ChatRepo chatRepo) : Hub
    {
        public async Task SendMessageToGroup(GroupChat chat)
        {
            var saveChatDTO = await chatRepo.AddChatToGroupAsync(chat);
            await Clients.All.SendAsync("ReceiveGroupMessages", saveChatDTO);
        }

        public async Task AddAvailableUser(AvailableUser availableUser)
        {
            availableUser.ConnectionId = Context.ConnectionId;
            var availableUsers = await chatRepo.AddAvailableUser(availableUser);
            await Clients.All.SendAsync("NotifyAllClients", availableUsers);
        }

        public async Task RemoveUser(string userId)
        {
            var availableUsers = await chatRepo.RemoveUserAsync(userId);
            await Clients.All.SendAsync("NotifyAllClients", availableUsers);
        }

        public async Task AddIndividualChat(IndividualChat individualChat)
        {
            await chatRepo.AddIndividualChatAsync(individualChat);
            var requestDTO = new RequestChatDTO()
            { ReceiverId = individualChat.ReceiverId, SenderId = individualChat.SenderId };
            var getChats = await chatRepo.GetIndividualChatsAsync(requestDTO);
            var prepareIndividualChat = new IndividualChatDTO()
            {
                SenderId = individualChat.SenderId,
                ReceiverId = individualChat.ReceiverId,
                Message = individualChat.Message,
                Date = individualChat.Date,
                ReceiverName = getChats.Where(_ => _.ReceiverId == individualChat.ReceiverId).FirstOrDefault()!.ReceiverName,
                SenderName = getChats.Where(_ => _.SenderId == individualChat.SenderId).FirstOrDefault()!.SenderName
            };
            await Clients.Users(individualChat.ReceiverId!).SendAsync("ReceiveIndividualMessage", prepareIndividualChat);
        }
    }
}
