using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace ManageApartments.Domain.Entities
{
    public class Hirer : FullAuditedEntity<int>
    {
        public int SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public byte[] RowVersion { get; set; }

    }
}