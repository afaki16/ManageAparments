using Abp.Application.Services.Dto;
using ManageApartments.Domain.Apartment.Dtos;
using ManageApartments.Domain.Building.Dtos;
using ManageApartments.Domain.ExpenseType.Dtos;
using ManageApartments.Domain.Hirer.Dtos;
using ManageApartments.Domain.Invoice.Dtos;
using System;
using System.Collections.Generic;

namespace ManageApartments.Domain.Expense.Dtos
{
    public class ExpenseFullOutput : EntityDto<int>
    {
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime? PriceDate { get; set; }
        public int ExpenseTypeId { get; set; }
        public ExpenseTypePartOutput ExpenseType { get; set; }
        public int BuildingId { get; set; }
        public BuildingPartOutput Building { get; set; }

    }
}