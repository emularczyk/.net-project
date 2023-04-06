using Microsoft.EntityFrameworkCore;
using Web_Forum.Models;

namespace Web_Forum.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }

        public DbSet<Comment> Comment { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Topic> Topic { get; set; }
    }
}
