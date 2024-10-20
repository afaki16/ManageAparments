using Abp.Application.Services.Dto;
using ManageApartments.Domain.Enums;
using ManageApartments.Domain.Hirer.Dtos;
using System;

namespace ManageApartments.Domain.InvoiceDetail.Dtos
{
    public class InvoiceDetailFullOutput : EntityDto<int>
    {
        public decimal Price { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public string Description { get; set; }
        public bool IsPaid { get; set; }
        public int? HirerId { get; set; }
        public HirerPartOutput Hirer { get; set; }
        


    }
}