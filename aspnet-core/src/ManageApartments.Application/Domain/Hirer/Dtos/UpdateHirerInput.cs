

using Abp.Application.Services.Dto;

namespace ManageApartments.Domain.Hirer.Dtos
{
    public class UpdateHirerInput : EntityDto<int>
    {
        public int SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? ApartmentId { get; set; }
    }
}
