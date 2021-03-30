using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramerwork
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, CarDbContext>, IUserOperationClaimDal
    {
    }
}
