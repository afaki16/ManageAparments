using Abp.Application.Services.Dto;
using ManageApartments.Domain.Building.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageApartments.Domain.ExpenseType.Dtos
{
    public class ExpenseTypePartOutput : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
