using Abp.Domain.Entities.Auditing;
using ManageApartments.Domain.Enums;
using System.Collections.Generic;

namespace ManageApartments.Domain.Entities
{
    public class Invoice : FullAuditedEntity<int>
    {
        public InvoiceType Type { get; set; }
        public string? SubscribeNo { get; set; }
        public string? ContractNo { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; }
        public int? ApartmentId { get; set; }
        public virtual Apartment Apartment { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public byte[] RowVersion { get; set; }

    }
}