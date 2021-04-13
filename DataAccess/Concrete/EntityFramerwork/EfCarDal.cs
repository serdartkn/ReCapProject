using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramerwork
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarDbContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (CarDbContext context = new CarDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join co in context.Colors on c.ColorId equals co.Id
                             let image = (from carImage in context.CarImages where c.Id == carImage.CarId select carImage.ImagePath)

                             select new CarDetailsDto
                             {
                                 CarId = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 CarName =c.CarName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ImagePath = image.Any() ? image.FirstOrDefault() : new CarImage { ImagePath = "Images/DefaultCar.jpg" }.ImagePath


                             };

                return result.ToList();
            }
        }


        public List<CarDetailsDto> GetCarsByPropName(Expression<Func<CarDetailsDto, bool>> filter = null)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join co in context.Colors on c.ColorId equals co.Id
                             let image = (from carImage in context.CarImages where c.Id == carImage.CarId select carImage.ImagePath)
                             select new CarDetailsDto
                             {
                                 CarId = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 CarName = c.CarName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ImagePath = image.Any() ? image.FirstOrDefault() : new CarImage { ImagePath = "Images/DefaultCar.jpg" }.ImagePath



                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
