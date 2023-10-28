using Microsoft.EntityFrameworkCore;
using ProtoolsStore.Domain.Entities;

namespace ProtoolsStore.Data.DbContexts;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tour>().Navigation(t => t.Attachment).AutoInclude();
        modelBuilder.Entity<Blog>().Navigation(b => b.Attachment).AutoInclude();
        modelBuilder.Entity<Order>().Navigation(b => b.Tour).AutoInclude();
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Tour> Tours { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Order> Orders { get; set; }

}