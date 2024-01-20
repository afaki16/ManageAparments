
using ManageApartments.Domain.Enums;

namespace ManageApartments.Domain.Invoice.Dtos
{
    public class CreateInvoiceInput
    {
        public InvoiceType Type { get; set; }
        public string? SubscribeNo { get; set; }
        public string? ContractNo { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; }
        public int? ApartmentId { get; set; }
    }

}
