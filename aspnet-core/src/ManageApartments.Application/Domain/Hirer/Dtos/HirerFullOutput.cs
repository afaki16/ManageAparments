using Abp.Application.Services.Dto;
using ManageApartments.Domain.Apartment.Dtos;
using ManageApartments.Domain.Building.Dtos;
using ManageApartments.Domain.InvoiceDetail.Dtos;
using System;
using System.Collections.Generic;

namespace ManageApartments.Domain.Hirer.Dtos
{
    public class HirerFullOutput : EntityDto<int>
    {
        public ulong SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? StartDate { get; set; }
        public int? UsageTime { get; set; }
        public int? Deposit { get; set; }
        public string? Profession { get; set; }
        public string? Description { get; set; }
        public int? ApartmentId { get; set; }
        public ApartmentPartOutput? Apartment { get; set; }
        public List<InvoiceDetailFullOutput> InvoiceDetails { get; set; }
        


    }
}