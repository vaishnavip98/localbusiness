using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class LBReactContext:DbContext
    {
        public LBReactContext(DbContextOptions<LBReactContext> options)
           : base(options)
        {
        }

        public DbSet<Login> Logins { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
    }
}
