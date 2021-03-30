using Core.Result.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService : ICrudRepository<Car>
    {
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailsDto>> GetCarDetails();
    }
}
