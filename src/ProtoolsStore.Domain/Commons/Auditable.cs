namespace ProtoolsStore.Domain.Commons;

public class Auditable : BaseEntity
{
    /// <summary>
    /// Entity created date GETTER & SETTER
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Entity updated date GETTER & SETTER
    /// </summary>
    public DateTime? UpdatedDate { get; set; }
}