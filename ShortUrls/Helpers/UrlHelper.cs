namespace ShortUrls.Helpers;

public class UrlHelper
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UrlHelper(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetBaseUrl()
    {
        var request = _httpContextAccessor.HttpContext?.Request;

        if (request != null)
        {
            var uriBuilder = new UriBuilder
            {
                Scheme = request.Scheme,
                Host = request.Host.Host,
                Port = request.Host.Port.GetValueOrDefault(80),
                Path = request.PathBase.ToString()
            };

            return uriBuilder.Uri.ToString();
        }

        return string.Empty;
    }

    public string GetShortUrl(string shorten)
    {
        return shorten.Replace(GetBaseUrl(), string.Empty);
    }
}
