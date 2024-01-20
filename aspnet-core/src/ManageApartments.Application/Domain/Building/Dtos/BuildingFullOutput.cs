using Abp.Application.Services.Dto;
using ManageApartments.Domain.Apartment.Dtos;
using System.Collections.Generic;

namespace ManageApartments.Domain.Building.Dtos
{
    public class BuildingFullOutput : EntityDto<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string BuildingNo { get; set; }
        public List<ApartmentFullOutput> Apartments { get; set; }
        

    }
}