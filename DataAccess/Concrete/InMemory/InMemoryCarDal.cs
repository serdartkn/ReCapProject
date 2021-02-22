using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car> {
                new Car{ Id = 1, BrandId=1, ColorId=1, ModelYear=2015, DailyPrice=250,Description="Temiz Araba"},
                new Car{ Id = 2, BrandId=2, ColorId=1, ModelYear=2019, DailyPrice=375,Description="Konforlu, rahat"},
                new Car{ Id = 3, BrandId=3, ColorId=2, ModelYear=2020, DailyPrice=550,Description="Lüks Araç"},
                new Car{ Id = 4, BrandId=1, ColorId=2, ModelYear=2002, DailyPrice=250,Description="Getir götür yapar"}
            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c => c.Id == car.Id);
            _car.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id) // Sadece bir araba geleceği için List<Car> demek yerine sadece Car diyoruz.

        {
            return _car.Where(c => c.Id == Id).ToList();
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
