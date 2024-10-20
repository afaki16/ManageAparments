using Abp.Application.Services.Dto;
using ManageApartments.Domain.Building.Dtos;
using ManageApartments.Domain.Electric.Dtos;
using ManageApartments.Domain.Fee.Dtos;
using ManageApartments.Domain.Hirer.Dtos;
using ManageApartments.Domain.Rent.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageApartments.Domain.Apartment.Dtos
{
    public class DetailApartmentOutput : EntityDto<int>
    {
        public int ApartmentId { get; set; }
        public string ApartmentName { get; set; }
        public Domain.Entities.Fee Fee { get; set; }
        public Domain.Entities.Rent Rent { get; set; }
        public Domain.Entities.Electric Electric { get; set; }

    }
}
