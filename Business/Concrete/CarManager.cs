using Business.Abstract;
using DataAccess.Abstract;
using Entities;
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

        public void Add(Car car)
        {
            if (car.CarName.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Başarıyla Kayıt Edildi.");
            }
            else
            {
                Console.WriteLine("Girilen Bilgileri Kontrol Edin!");
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(b => b.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }
    }
}
