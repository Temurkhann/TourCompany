using Microsoft.EntityFrameworkCore;
using ProtoolsStore.Domain.Entities;

namespace ProtoolsStore.Data.DbContexts;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Tour> Tours { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Order> Orders { get; set; }

}