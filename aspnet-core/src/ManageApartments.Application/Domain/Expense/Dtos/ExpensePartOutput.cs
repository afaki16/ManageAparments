using Abp.Application.Services.Dto;
using ManageApartments.Domain.Building.Dtos;
using ManageApartments.Domain.ExpenseType.Dtos;
using System;


namespace ManageApartments.Domain.Expense.Dtos
{
    public class ExpensePartOutput : EntityDto<int>
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
