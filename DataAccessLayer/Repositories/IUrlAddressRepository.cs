using Domain;

namespace DataAccessLayer;

public interface IUrlAddressRepository : IRepository<UrlAddress>
{ 
    Task<UrlAddress?> GetByShortUrlAsync(string shortUrl);
    Task<UrlAddress?> GetByOriginalUrlAsync(string originalUrl);
    Task<UrlAddress> CreateAsync(UrlAddress url);
}
