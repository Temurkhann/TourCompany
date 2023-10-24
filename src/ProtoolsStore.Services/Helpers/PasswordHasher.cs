namespace ProtoolsStore.Services;

/// <summary>
/// Utility class for hashing, verifying, and changing passwords using BCrypt algorithm with a secret key.
/// </summary>
public static class PasswordHasher
{
    /// <summary>
    /// Secret key used for password hashing.
    /// </summary>
    private const string key = "fed9e0ew234da-9169-412f2-9745-84790ddfabd9";

    /// <summary>
    /// Hashes the specified password using BCrypt algorithm combined with the secret key.
    /// </summary>
    /// <param name="password">The password to be hashed.</param>
    /// <returns>The hashed password.</returns>
    public static string Hash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password + key);
    }

    /// <summary>
    /// Verifies if the specified password matches the given hash using BCrypt algorithm with the secret key.
    /// </summary>
    /// <param name="password">The password to be verified.</param>
    /// <param name="hash">The hash to be compared against.</param>
    /// <returns>True if the password matches the hash; otherwise, false.</returns>
    public static bool Verify(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password + key, hash);
    }
}
