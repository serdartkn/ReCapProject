using Core.Result.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService : ICrudRepository<Customer>
    {
    }
}
