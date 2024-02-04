using BusinessLogicalLayer.Base;
using DataAccessLayer;

namespace BusinessLogicalLayer;

internal class Shortener : IShortener
{
    private const int _lengthUrl = 6;
    private readonly IUrlAddressRepository _repository;

    public Shortener(IUrlAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> GetOrCreateShortUrl(string originalUrl)
    {
        var result = await _repository.GetByOriginalUrlAsync(originalUrl);
        if(result is not null)
        {
            return result.ShortUrl!;
        }

        string shortUrl;
        do
        {
            shortUrl = Guid.NewGuid().ToString()[.._lengthUrl];
        }
        while ((await _repository.GetByShortUrlAsync(shortUrl)) is not null);
        
        result = new() { OriginalUrl = originalUrl, ShortUrl = shortUrl };

        await _repository.CreateAsync(result);

        return shortUrl;
    }

    public async Task<string?> GetOriginalUrl(string shortUrl)
    {
        var result = await _repository.GetByShortUrlAsync(shortUrl);
        return result?.OriginalUrl;
    }
}
