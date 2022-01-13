using IdentityService.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Infrastructure.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<UserDetails> User_Detail { get; set; }
    }
}
