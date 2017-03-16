using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RedoCommunityApp.Models;
using Microsoft.EntityFrameworkCore;

namespace RedoCommunityApp.Repositories
{
    public class AppIdentityDbContext : IdentityDbContext<Member>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options) { }
    }
}
