

namespace ManageApartments.Domain.Apartment.Dtos
{
    public class CreateApartmentInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? RoofNo { get; set; }
        public bool? IsActive { get; set; }
        public int? BuildingId { get; set; }
    }

}
