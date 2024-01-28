﻿using Abp.Domain.Entities.Auditing;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace ManageApartments.Domain.Entities
{
    public class Hirer : FullAuditedEntity<int>
    {
        public ulong SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //Belgeler için property
        //public int MyProperty { get; set; }
        public bool? IsActive{ get; set; }
        public DateTime? StartDate  { get; set; }
        public int? UsageTime { get; set; }
        public string? Description { get; set; }
        public int? ApartmentId { get; set; }
        public virtual Apartment Apartment { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public byte[] RowVersion { get; set; }

    }
}