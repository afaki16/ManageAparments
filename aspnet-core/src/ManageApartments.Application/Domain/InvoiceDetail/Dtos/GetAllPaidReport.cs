using Abp.Application.Services.Dto;
using ManageApartments.Domain.Enums;
using ManageApartments.Domain.Hirer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageApartments.Domain.InvoiceDetail.Dtos
{
    public class GetAllPaidReport : EntityDto<int>
    {
        public decimal TotalPrice { get; set; }
        public string Apartment { get; set; }
        public InvoiceType InvoiceType { get; set; }
       

    }
}


