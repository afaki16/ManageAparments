using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageApartments.EntityFrameworkCore.Repositories.Contracts.LoginImage
{
    public interface ILoginImageRepository : IRepository<Domain.Entities.LoginImage, int>
    {

    }
}
