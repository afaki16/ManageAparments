using Abp.EntityFrameworkCore;
using ManageApartments.EntityFrameworkCore.Repositories.Contracts.LoginImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageApartments.EntityFrameworkCore.Repositories.Extensions.LoginImage
{
    public class LoginImageRepository : ManageApartmentsRepositoryBase<Domain.Entities.LoginImage, int>, ILoginImageRepository
    {
        public LoginImageRepository(IDbContextProvider<ManageApartmentsDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
