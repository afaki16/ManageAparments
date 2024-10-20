using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageApartments.Domain.Entities
{
    public class Electric : FullAuditedEntity<int>
    {
        public string NumeratorNo { get; set; }
        public int? StaticKW { get; set; }
        public int? KW { get; set; }
        public bool? IsActive { get; set; }
        public int? ApartmentId { get; set; }
        public virtual Apartment Apartment { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
