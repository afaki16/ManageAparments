using Abp.Domain.Entities.Auditing;
using ManageApartments.Domain.Enums;
using System;

namespace ManageApartments.Domain.Entities
{
    public class InvoiceDetail : FullAuditedEntity<int>
    {
        public decimal Price { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public string Description{ get; set; }
        public bool IsPaid { get; set; }
        public int? HirerId { get; set; }
        public virtual Hirer Hirer { get; set; }
        public byte[] RowVersion { get; set; }

    }
}