using Abp.Application.Services.Dto;
using ManageApartments.Domain.Apartment.Dtos;
using ManageApartments.Domain.Building.Dtos;
using ManageApartments.Domain.Enums;
using ManageApartments.Domain.InvoiceDetail.Dtos;
using System.Collections.Generic;

namespace ManageApartments.Domain.Invoice.Dtos
{
    public class InvoiceFullOutput : EntityDto<int>
    {
        public InvoiceType Type { get; set; }
        public string? SubscribeNo { get; set; }
        public string? ContractNo { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; }
        public int? ApartmentId { get; set; }
        public ApartmentPartOutput Apartment { get; set; }
        public List<InvoiceDetailFullOutput> InvoiceDetails { get; set; }


    }
}