﻿using Abp.Application.Services.Dto;

namespace ManageApartments.Domain.Electric.Dtos
{
    public class UpdateElectricInput : EntityDto<int>
    {
        public string NumeratorNo { get; set; }
        public int? StaticKW { get; set; }
        public int? KW { get; set; }
        public bool? IsActive { get; set; }
        public int? ApartmentId { get; set; }
    }
}
