﻿using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car> {
                new Car{ CarId = 1, BrandId=1, ColorId=1, ModelYear=2015, DailyPrice=250,Description="Temiz Araba"},
                new Car{ CarId = 2, BrandId=2, ColorId=1, ModelYear=2019, DailyPrice=375,Description="Konforlu, rahat"},
                new Car{ CarId = 3, BrandId=3, ColorId=2, ModelYear=2020, DailyPrice=550,Description="Lüks Araç"},
                new Car{ CarId = 4, BrandId=1, ColorId=2, ModelYear=2002, DailyPrice=250,Description="Getir götür yapar"}
            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c => c.CarId == car.CarId);
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
            return _car.Where(c => c.CarId == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
