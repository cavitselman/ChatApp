using CApp.Authentication;
using CAppModels.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace CApp.Data
{
    public class Context : IdentityDbContext<AppUser>
    {
        public Context(DbContextOptions<Context> options) : base(options) 
        { 
        }

        public DbSet<GroupChat> GroupChats { get; set; }
        public DbSet<AvailableUser> AvailableUsers { get; set; }
        public DbSet<IndividualChat> IndividualChats { get; set; }
    }
}
