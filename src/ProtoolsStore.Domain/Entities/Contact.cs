using ProtoolsStore.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoolsStore.Domain.Entities
{
    public class Contact : Auditable
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
    }
}
