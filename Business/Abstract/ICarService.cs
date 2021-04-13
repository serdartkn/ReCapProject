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
        IDataResult<List<CarDetailsDto>> GetCarsByBrandName(string brand);
        IDataResult<List<CarDetailsDto>> GetCarsByColorName(string color);
        IDataResult<List<CarDetailsDto>> GetCarDetails();
        IDataResult<List<CarDetailsDto>> GetCarDetailsbyId(int id);
    }
}
