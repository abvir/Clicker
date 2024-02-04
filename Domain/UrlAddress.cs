namespace Domain;

public class UrlAddress : Entity
{
    public string OriginalUrl {get;set;} = null!;
    public string ShortUrl {get;set;} = null!;
}
