﻿using Abp.Application.Services.Dto;
using ManageApartments.Domain.Apartment.Dtos;
using System;

namespace ManageApartments.Domain.Fee.Dtos
{
    public class FeeFullOutput : EntityDto<int>
    {
        public DateTime? StartDate { get; set; }
        public decimal Price { get; set; }
        public bool? IsActive { get; set; }
        public int? ApartmentId { get; set; }
        public ApartmentPartOutput Apartment { get; set; }


    }
}