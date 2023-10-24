using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ProtoolsStore.Services;

/// <summary>
/// Custom validation attribute to check if the uploaded file has an allowed extension.
/// </summary>
public class FileExtensionsAttribute : ValidationAttribute
{
    private readonly string[] _allowedExtensions;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileExtensionsAttribute"/> class with the allowed file extensions.
    /// </summary>
    /// <param name="allowedExtensions">A list of allowed file extensions.</param>
    public FileExtensionsAttribute(params string[] allowedExtensions)
    {
        _allowedExtensions = allowedExtensions;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FileExtensionsAttribute"/> class with a string containing allowed file extensions separated by space.
    /// </summary>
    /// <param name="allowedExtensions">A string containing allowed file extensions separated by space.</param>
    public FileExtensionsAttribute(string allowedExtensions)
    {
        _allowedExtensions = allowedExtensions.Split(" ");
    }

    /// <summary>
    /// Validates if the uploaded file has an allowed extension.
    /// </summary>
    /// <param name="value">The file to be validated.</param>
    /// <param name="validationContext">The validation context.</param>
    /// <returns>ValidationResult indicating success or failure of the validation.</returns>
    protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
    {
        if (value is IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);

            if (Array.IndexOf(_allowedExtensions, extension?.ToLower()) == -1)
            {
                return new ValidationResult($"Invalid file extension. Allowed extensions are: {string.Join(", ", _allowedExtensions)}");
            }
        }

        return ValidationResult.Success;
    }
}
