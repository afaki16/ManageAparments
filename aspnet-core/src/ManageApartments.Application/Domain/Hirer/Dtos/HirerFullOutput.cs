using Abp.Application.Services.Dto;
using ManageApartments.Domain.Apartment.Dtos;
using ManageApartments.Domain.Building.Dtos;
using ManageApartments.Domain.InvoiceDetail.Dtos;
using System.Collections.Generic;

namespace ManageApartments.Domain.Hirer.Dtos
{
    public class HirerFullOutput : EntityDto<int>
    {
        public int SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public int? ApartmentId { get; set; }
        public ApartmentPartOutput? Apartment { get; set; }
        public List<InvoiceDetailFullOutput> InvoiceDetails { get; set; }
        


    }
}