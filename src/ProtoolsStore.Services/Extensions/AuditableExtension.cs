using ProtoolsStore.Domain.Commons;

namespace ProtoolsStore.Services;

/// <summary>
/// Extension methods for handling audit-related operations on objects implementing the Auditable interface.
/// </summary>
public static class AuditableExtension
{
    /// <summary>
    /// Sets the created date and created by properties of the Auditable object using the current UTC time and the user ID from the HttpContext.
    /// </summary>
    /// <param name="auditable">The auditable object to be created.</param>
    public static void Create(this Auditable auditable)
    {
        auditable.CreatedDate = DateTime.UtcNow;
    }

    /// <summary>
    /// Sets the updated date and updated by properties of the Auditable object using the current UTC time and the user ID from the HttpContext.
    /// </summary>
    /// <param name="auditable">The auditable object to be updated.</param>
    public static void Update(this Auditable auditable)
    {
        auditable.UpdatedDate = DateTime.UtcNow;
    }
}
