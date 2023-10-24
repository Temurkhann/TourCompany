using System.ComponentModel.DataAnnotations;

namespace ProtoolsStore.Services;

/// <summary>
/// Custom validation attribute to check if the password meets strong password requirements.
/// </summary>
public class StrongPasswordAttribute : ValidationAttribute
{
    /// <summary>
    /// Validates if the password meets strong password requirements.
    /// </summary>
    /// <param name="value">The password to be validated.</param>
    /// <param name="validationContext">The validation context.</param>
    /// <returns>ValidationResult indicating success or failure of the validation.</returns>
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Password cannot be null");
        }

        string? password = value.ToString();

        if (password is { Length: < 8 })
        {
            return new ValidationResult("Password must be at least 8 characters");
        }

        if (password is { Length: > 50 })
        {
            return new ValidationResult("Password must be less than 50 characters");
        }

        var result = IsStrong(password);

        return !result.IsValid ? new ValidationResult(result.Message) : ValidationResult.Success;
    }

    private static (bool IsValid, string Message) IsStrong(string? password)
    {
        bool isLower = false;
        bool isUpper = false;
        bool isDigit = false;
        bool isSpecialChar = false;

        if (password != null)
            foreach (char c in password)
            {
                if (char.IsLower(c))
                {
                    isLower = true;
                }
                else if (char.IsUpper(c))
                {
                    isUpper = true;
                }
                else if (char.IsDigit(c))
                {
                    isDigit = true;
                }
                else if ("!@#$%^&*()_+".Contains(c))
                {
                    isSpecialChar = true;
                }
            }

        if (!isLower)
        {
            return (IsValid: false, Message: "Password must contain at least one lowercase letter");
        }

        if (!isUpper)
        {
            return (IsValid: false, Message: "Password must contain at least one uppercase letter");
        }

        if (!isDigit)
        {
            return (IsValid: false, Message: "Password must contain at least one digit");
        }

        if (!isSpecialChar)
        {
            return (IsValid: false, Message: "Password must contain at least one special character (!@#$%^&*()_+)");
        }

        return (IsValid: true, Message: "Password is strong");
    }
}
