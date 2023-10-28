using ProtoolsStore.Domain.Commons;

namespace ProtoolsStore.Domain.Entities;

public class Blog : Auditable
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public long? AttachmentId { get; set; }
    public Attachment? Attachment { get; set; } = null!;
}

