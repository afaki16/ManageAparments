
using Abp.Application.Services.Dto;

namespace ManageApartments.Domain.Apartment.Dtos
{
    public class UpdateApartmentInput : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? RoofNo { get; set; }
        public int? BuildingId { get; set; }
    }
}
