using System.ComponentModel.DataAnnotations;

namespace ShortUrls.Helpers;

//[RegularExpression(@"^(http|https):\/\/[^\s]+$", ErrorMessage = "Invalid URL format")]
public class UrlAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            string url = value.ToString()!;
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                return ValidationResult.Success!;
            }
        }

        return new ValidationResult(ErrorMessage ?? "Invalid URL format")!;
    }
}

