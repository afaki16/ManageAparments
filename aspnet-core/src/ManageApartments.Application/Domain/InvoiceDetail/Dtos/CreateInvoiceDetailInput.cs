﻿using ManageApartments.Domain.Enums;
using System;

namespace ManageApartments.Domain.InvoiceDetail.Dtos
{ 
    public class CreateInvoiceDetailInput
    {
        public decimal Price { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public string Description { get; set; }
        public bool IsPaid { get; set; }
        public int? HirerId { get; set; }
       
    }

}
