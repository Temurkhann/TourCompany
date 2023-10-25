using ProtoolsStore.Domain.Commons;
using ProtoolsStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProtoolsStore.Domain.Entities;

public class Tour : Auditable
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Price { get; set; } = null!;
    public long AttachmentId { get; set; }
    public Attachment Attachment { get; set; } = null!;

}
