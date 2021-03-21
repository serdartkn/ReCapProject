using Core.Result.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailsDto>> GetCarDetails();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
    }
}
