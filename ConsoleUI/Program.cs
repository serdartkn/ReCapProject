using Business;
using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramerwork;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    { 
        static void Main(string[] args)
        {
            //CarTest();
            //ColorTest();
            //BrandTest();

            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
            }
            

        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(new Brand { BrandName = "Toyota" });
            //brandManager.Update(new Brand {BrandId=2, BrandName = "Renault" });
            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.BrandName);
            //}
            //var result = brandManager.GetById(2);
            //Console.WriteLine(result.BrandId +" "+result.BrandName);

            //Branddenemesi yapılığ dto olusturulacak
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //colorManager.Add(new Color{ColorName="Beyaz",});
            //colorManager.Update(new Color {ColorId=3 ,ColorName = "Kırmızı"});
            //colorManager.Delete(new Color { ColorId = 1, ColorName = "Kırmızı" });
            //var result = colorManager.GetById(2);
            //Console.WriteLine(result.ColorId + " " + result.ColorName);

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //carManager.Add(new Car {BrandId = 9, ColorId = 9, CarName = "opo12p", ModelYear = 9, DailyPrice = 201, Description = "op1212op" });
            //carManager.Update(new Car {Id=1003,BrandId=9,ColorId=9,CarName="Citroen",ModelYear=2009,DailyPrice=150,Description="Küçük, Rahat"});
            //carManager.Delete(new Car {Id = 1002, BrandId = 9, ColorId = 9, CarName = "opop", ModelYear = 9, DailyPrice = 201, Description = "opop" });
            //var result = carManager.GetById(4);
            //Console.WriteLine(result.Id +" "+ result.CarName);

            foreach (var product in carManager.GetAll())
            {
                Console.WriteLine(product.CarName + " " + product.DailyPrice + "TL");
            }
        }
    }
}
