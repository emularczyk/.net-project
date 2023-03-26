using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient.X.XDevAPI.Common;
using Web_Forum.Models;

namespace Web_Forum.Data;

public class IdentityApplicationDbContext : IdentityDbContext<User>
{
    public IdentityApplicationDbContext(DbContextOptions<IdentityApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Comment> Comment { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Topic> Topic { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<User>().Ignore(c => c.AccessFailedCount)
                            .Ignore(c => c.LockoutEnabled)
                            .Ignore(c => c.ConcurrencyStamp)
                            .Ignore(c => c.EmailConfirmed)
                            .Ignore(c => c.UserRoles)
                            .Ignore(c => c.LockoutEnd)
                            .Ignore(c => c.NormalizedEmail)
                            .Ignore(c => c.NormalizedUserName)
                            .Ignore(c => c.PhoneNumber)
                            .Ignore(c => c.PhoneNumberConfirmed)
                            .Ignore(c => c.SecurityStamp)
                            .Ignore(c => c.TwoFactorEnabled);
        builder.Entity<User>().ToTable("user").Property(p => p.Id).HasColumnName("id");

        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
