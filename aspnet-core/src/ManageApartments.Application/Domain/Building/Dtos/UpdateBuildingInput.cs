

using Abp.Application.Services.Dto;

namespace ManageApartments.Domain.Building.Dtos
{
    public class UpdateBuildingInput : EntityDto<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string BuildingNo { get; set; }
    }
}
