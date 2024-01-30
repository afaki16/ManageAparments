using Abp.Application.Services.Dto;
using ManageApartments.Domain.Hirer.Dtos;
using System;

namespace ManageApartments.Domain.InvoiceDetail.Dtos
{
    public class InvoiceDetailFullOutput : EntityDto<int>
    {
        public int Price { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime? LastPaymentDate { get; set; }
        public bool IsPaid { get; set; }
        public int? HirerId { get; set; }
        public HirerPartOutput Hirer { get; set; }
        


    }
}