using Business.Abstract;
using Business.Constants;
using Core.Result.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.CarName.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccesResult(Messages.CarAdded);
            }
            
            return new ErrorResult(Messages.CarAddInvalid);
        }

        public IResult Delete(Car car)
        {
            if (car.CarName.Length < 2)
            {
                return new ErrorResult(Messages.CarAddInvalid);
            }

            _carDal.Delete(car);
            return new SuccesResult(Messages.CarDeleted);

        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarListInvalid);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<Car> GetById(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == Id), Messages.CarListed);
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetailsbyId(int id)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarsByPropName(c => c.CarId == id));
        }

        public IDataResult<List<CarDetailsDto>> GetCarsByBrandName(string brand)
        {
          return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarsByPropName(b => b.BrandName == brand));
        }

        public IDataResult<List<CarDetailsDto>> GetCarsByColorName(string color)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarsByPropName(b => b.ColorName == color));
        }


        public IResult Update(Car car)
        {
            if (car.CarName.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Update(car);
                return new SuccesResult(Messages.CarUpdated);
            }
            
            return new ErrorResult(Messages.CarAddInvalid);
        }
    }
}