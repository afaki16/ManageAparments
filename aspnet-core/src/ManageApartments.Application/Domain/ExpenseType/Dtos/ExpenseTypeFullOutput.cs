using Abp.Application.Services.Dto;
using ManageApartments.Domain.Expense.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageApartments.Domain.ExpenseType.Dtos
{
    public class ExpenseTypeFullOutput : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ExpenseFullOutput> Expenses { get; set; }
       
    }
}
