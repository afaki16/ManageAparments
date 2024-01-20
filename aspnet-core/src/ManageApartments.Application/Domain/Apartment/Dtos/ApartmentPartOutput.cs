using Abp.Application.Services.Dto;
using ManageApartments.Domain.Building.Dtos;


namespace ManageApartments.Domain.Apartment.Dtos
{
    public class ApartmentPartOutput : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? BlokNo { get; set; }
        public int? BuildingId { get; set; }
        public BuildingPartOutput Building { get; set; }
    }
}
