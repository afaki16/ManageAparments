

using Abp.Application.Services.Dto;
using System;

namespace ManageApartments.Domain.Expense.Dtos
{
    public class UpdateExpenseInput : EntityDto<int>
    {
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime? PriceDate { get; set; }
        public int ExpenseTypeId { get; set; }
        public int BuildingId { get; set; }
    }
}
