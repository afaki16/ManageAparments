using Abp.Domain.Entities.Auditing;
using System;

namespace ManageApartments.Domain.Entities
{
    public class InvoiceDetail : FullAuditedEntity<int>
    {
        public int Price { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime? LastPaymentDate { get; set; }
        public bool IsPaid { get; set; }
        public int? HirerId { get; set; }
        public virtual Hirer Hirer { get; set; }
        public byte[] RowVersion { get; set; }

    }
}