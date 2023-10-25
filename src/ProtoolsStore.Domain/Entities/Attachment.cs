using ProtoolsStore.Domain.Commons;

namespace ProtoolsStore.Domain.Entities;

public class Attachment : Auditable
{
    public string Path { get; set; }

    public Blog Blog { get; set; }
    public Tour Tour { get; set; }  
}
