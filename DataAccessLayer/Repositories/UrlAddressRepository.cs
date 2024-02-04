using Domain;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;

internal class UrlAddressRepository : IUrlAddressRepository
{
    private readonly ShortUrlContext _context;

    public UrlAddressRepository(ShortUrlContext context)
    {
        _context = context;
    }

    public async Task<UrlAddress> CreateAsync(UrlAddress url)
    {
        var result = (await _context.Urls.AddAsync(url));
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<UrlAddress?> GetByOriginalUrlAsync(string originalUrl)
    {
        var result = await _context.Urls.FirstOrDefaultAsync(x => x.OriginalUrl == originalUrl);
        return result;
    }

    public async Task<UrlAddress?> GetByShortUrlAsync(string shortUrl)
    {
        var result = await _context.Urls.FirstOrDefaultAsync(x => x.ShortUrl == shortUrl);
        return result;
    }
}
