using Abp.Application.Services.Dto;
using ManageApartments.Domain.Building.Dtos;
using ManageApartments.Domain.Hirer.Dtos;
using ManageApartments.Domain.Invoice.Dtos;
using System.Collections.Generic;

namespace ManageApartments.Domain.Apartment.Dtos
{
    public class ApartmentFullOutput : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? RoofNo { get; set; }
        public int? BuildingId { get; set; }
        public BuildingPartOutput Building { get; set; }
        public virtual List<InvoiceFullOutput> Invoices { get; set; }
        public virtual List<HirerFullOutput> Hirers { get; set; }




    }
}