using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    public class AuditableEntity<TId> : BaseEntity<TId>
    {
        public DateTime? Added { get; set; }
        public DateTime? Modified { get; set; }
        public int? AddedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
