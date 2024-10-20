using System;

namespace ManageApartments.Domain.Rent.Dtos
{ 
    public class CreateRentInput
    {
        public DateTime? StartDate { get; set; }
        public decimal Price { get; set; }
        public bool? IsActive { get; set; }
        public int? ApartmentId { get; set; }
    }

}
