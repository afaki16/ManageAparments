using Abp.Application.Services.Dto;
using ManageApartments.Domain.Apartment.Dtos;

namespace ManageApartments.Domain.Electric.Dtos
{
    public class ElectricFullOutput : EntityDto<int>
    {
        public string NumeratorNo { get; set; }
        public int? StaticKW { get; set; }
        public int? KW { get; set; }
        public bool? IsActive { get; set; }
        public int? ApartmentId { get; set; }
        public ApartmentPartOutput Apartment { get; set; }


    }
}