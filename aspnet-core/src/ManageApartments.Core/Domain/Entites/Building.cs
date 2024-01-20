using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace ManageApartments.Domain.Entities

{
    public class Building : FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string BuildingNo { get; set; }
        //public string State { get; set; }
        //public string City{ get; set; }
        public virtual ICollection<Apartment> Apartments { get; set; }
        public byte[] RowVersion { get; set; }

    }
}