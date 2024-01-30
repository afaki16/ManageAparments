using Abp.Application.Services.Dto;
using ManageApartments.Domain.Building.Dtos;
using ManageApartments.Domain.Electric.Dtos;
using ManageApartments.Domain.Fee.Dtos;
using ManageApartments.Domain.Hirer.Dtos;
using ManageApartments.Domain.Rent.Dtos;
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
        public List<HirerFullOutput> Hirers { get; set; }
        public List<ElectricFullOutput> Electrics { get; set; }
        public List<FeeFullOutput> Fees { get; set; }
        public List<RentFullOutput> Rents { get; set; }




    }
}