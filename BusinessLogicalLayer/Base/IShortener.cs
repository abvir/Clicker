namespace BusinessLogicalLayer.Base;

public interface IShortener
{
    Task<string> GetOrCreateShortUrl(string originalUrl);
    Task<string?> GetOriginalUrl(string shortUrl);
}
