using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccessLayer.Contexts;

internal class ShortUrlContextDesignFactory : IDesignTimeDbContextFactory<ShortUrlContext>
{
    private const string _connectionString = "Host=localhost;Port=5432;Database=short_url_db;Username=postgres;Password=password";
    
    public ShortUrlContext CreateDbContext(string[] args){
        var optionsBuilder = new DbContextOptionsBuilder<ShortUrlContext>();
        optionsBuilder.UseNpgsql(_connectionString);
        return new ShortUrlContext(optionsBuilder.Options);
	}
}
