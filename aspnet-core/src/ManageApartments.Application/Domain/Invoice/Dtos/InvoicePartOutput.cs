using Abp.Application.Services.Dto;
using ManageApartments.Domain.Apartment.Dtos;
using ManageApartments.Domain.Enums;


namespace ManageApartments.Domain.Invoice.Dtos
{
    public class InvoicePartOutput : EntityDto<int>
    {
        public InvoiceType Type { get; set; }
        public string? NumeratorNo { get; set; }
        public string? ContractNo { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; }
        public int? ApartmentId { get; set; }
        public ApartmentPartOutput Apartment { get; set; }
    }
}
