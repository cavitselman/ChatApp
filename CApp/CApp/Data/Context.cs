using CApp.Authentication;
using CAppModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace CApp.Data
{
    public class Context : IdentityDbContext<AppUser>
    {
        public Context(DbContextOptions<Context> options) : base(options) 
        { 
        }

        public DbSet<Chat> Chats { get; set; }
    }
}
