using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageApartments.Domain.ExpenseType.Dtos
{
    public class UpdateExpenseTypeInput : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
