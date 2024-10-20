using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageApartments.Domain.Entities
{
    public class LoginImage : FullAuditedEntity<int>
    {
        public string PhotoUrl { get; set; }
    }
}
