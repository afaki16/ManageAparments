using Abp.Application.Services.Dto;
using ManageApartments.Domain.Enums;

namespace ManageApartments.Domain.Invoice.Dtos
{
    public class UpdateInvoiceInput : EntityDto<int>
    {
        public InvoiceType Type { get; set; }
        public string? SubscribeNo { get; set; }
        public string? ContractNo { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; }
        public int? ApartmentId { get; set; }
    }
}
