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
    
    /// <summary>
    /// Entity created by GETTER & SETTER
    /// </summary>
    public long? CreatedBy { get; set; }

    /// <summary>
    /// Entity updated by GETTER & SETTER
    /// </summary>
    public long? UpdatedBy { get; set; }
}