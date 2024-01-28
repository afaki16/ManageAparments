

using Abp.Application.Services.Dto;
using System;

namespace ManageApartments.Domain.Hirer.Dtos
{
    public class UpdateHirerInput : EntityDto<int>
    {
        public ulong SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? StartDate { get; set; }
        public int? UsageTime { get; set; }
        public string? Description { get; set; }
        public int? ApartmentId { get; set; }
    }
}
