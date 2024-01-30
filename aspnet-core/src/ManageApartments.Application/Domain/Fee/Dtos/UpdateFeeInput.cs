using Abp.Application.Services.Dto;
using System;

namespace ManageApartments.Domain.Fee.Dtos
{
    public class UpdateFeeInput : EntityDto<int>
    {
        public DateTime? StartDate { get; set; }
        public decimal Price { get; set; }
        public bool? IsActive { get; set; }
        public int? ApartmentId { get; set; }
    }
}
