using CApp.Data;
using CAppModels;
using Microsoft.EntityFrameworkCore;

namespace CApp.Repos
{
    public class ChatRepo(Context context)
    {
        public async Task SaveChatAsync(Chat chat)
        {
            context.Chats.Add(chat);
            await context.SaveChangesAsync();
        }

        public async Task<List<Chat>> GetChatsAsync()
            => await context.Chats.ToListAsync();
    }
}
