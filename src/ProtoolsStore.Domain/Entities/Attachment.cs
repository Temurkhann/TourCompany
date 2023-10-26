using ProtoolsStore.Domain.Commons;

namespace ProtoolsStore.Domain.Entities;

public class Attachment : Auditable
{
    public string Path { get; set; } = null!;
    public string Name { get; set; } = null!;

    public Blog Blog { get; set; } = null!;
    public Tour Tour { get; set; } = null!;
}
