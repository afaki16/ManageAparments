
using ManageApartments.Domain.Apartment.Dtos;
using ManageApartments.Domain.Building.Dtos;
using System.Collections.Generic;

namespace ManageApartments.Domain.Hirer.Dtos
{ 
    public class CreateHirerInput
    {
        public int SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? ApartmentId { get; set; }
       
    }

}
