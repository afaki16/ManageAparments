 using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace ManageApartments.Domain.Entities
{
    public class Apartment : FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? RoofNo { get; set; }
        public int? BuildingId { get; set; }
        public virtual Building Building { get; set; }
        public virtual ICollection<Hirer> Hirers { get; set; }
        public virtual ICollection<Electric> Electrics { get; set; }
        public virtual ICollection<Fee> Fees { get; set; }
        public virtual ICollection<Rent> Rents { get; set; }
        public byte[] RowVersion { get; set; }

    }
}