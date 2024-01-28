using Abp.Domain.Entities.Auditing;
using ManageApartments.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageApartments.Domain.Entites
{
    public class Expense : FullAuditedEntity<int>
    {
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime? PriceDate { get; set; }
        public int ExpenseTypeId { get; set; }
        public virtual ExpenseType ExpenseType { get; set; }
        public int BuildingId { get; set; }
        public virtual Building Building { get; set; }
        public byte[] RowVersion { get; set; }


    }
}
