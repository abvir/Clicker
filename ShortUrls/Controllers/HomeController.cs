using Microsoft.AspNetCore.Mvc;
using ShortUrls.Models;
using System.Diagnostics;
using BusinessLogicalLayer.Base;
using ShortUrls.Helpers;

namespace ShortUrls.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UrlHelper _urlHelper;
    private readonly IShortener _shortener;

    public HomeController(ILogger<HomeController> logger, IShortener shortener, UrlHelper urlHelper)
    {
        _logger = logger;
        _shortener = shortener;
        _urlHelper = urlHelper;
    }

    public IActionResult Index()
    {
               
        return View();
    }

    [HttpPost]
    [Route("shorten_url")]
    public async Task<IActionResult> ShortenUrl([Url] string originalUrl)
    {
        if (ModelState.IsValid)
        {
            string shortCode = await _shortener.GetOrCreateShortUrl(originalUrl);
            string shortUrl = _urlHelper.GetBaseUrl() + shortCode;
            ViewBag.ShortUrl = shortUrl;
            return View("Index");
        }
        ViewBag.Error = "Not url";
        return View("Index");
    }

    [HttpGet]
    [Route("{shortUrl}")]
    public async Task<IActionResult> RedirectToUrl(string shortUrl)
    {
        string? originalUrl = await _shortener.GetOriginalUrl(shortUrl);
        
        if (string.IsNullOrEmpty(originalUrl))
        {
            ViewBag.Error = "Not found";
            return View("Index");
        }
        return Redirect(originalUrl);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

