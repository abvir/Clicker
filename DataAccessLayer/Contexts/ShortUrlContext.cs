using Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccessLayer.Contexts;

public class ShortUrlContext : DbContext
{
    public DbSet<UrlAddress> Urls { get; set; }
    
    public ShortUrlContext(DbContextOptions options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }    
}
