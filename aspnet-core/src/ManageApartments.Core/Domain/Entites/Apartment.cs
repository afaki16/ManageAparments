using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace ManageApartments.Domain.Entities
{
    public class Apartment : FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? BlokNo { get; set; }
        public int? BuildingId { get; set; }
        public Hirer? Hirer { get; set; }
        public virtual Building Building { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public byte[] RowVersion { get; set; }

    }
}