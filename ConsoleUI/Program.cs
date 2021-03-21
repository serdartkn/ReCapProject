using Business;
using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramerwork;
using Entities.Concrete;
using Business.Constants;

namespace ConsoleUI
{
    class Program
    {

        static void Main(string[] args)
        {
            //CarTest();
            //ColorTest();
            //BrandTest(); 
            //CustomerTest();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental
            {
                CarId = 1003, 
                CustomerId = 2, 
                RentDate = new DateTime(2020, 12, 15)


            });


        }

        private static void CustomerTest()
        {
            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //customerManager.Add(new Customer { UserId = 1, CompanyName = "Mil" });
        }

        private static void BrandTest()
        {
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            ////brandManager.Add(new Brand { BrandName = "Toyota" });
            ////brandManager.Update(new Brand {BrandId=2, BrandName = "Renault" });
            ////foreach (var brand in brandManager.GetAll())
            ////{
            ////    Console.WriteLine(brand.BrandName);
            ////}
            ////var result = brandManager.GetById(2);
            ////Console.WriteLine(result.BrandId +" "+result.BrandName);

            ////Branddenemesi yapılığ dto olusturulacak
        }

        private static void ColorTest()
        {
            //ColorManager colorManager = new ColorManager(new EfColorDal());

            ////colorManager.Add(new Color{ColorName="Beyaz",});
            ////colorManager.Update(new Color {ColorId=3 ,ColorName = "Kırmızı"});
            ////colorManager.Delete(new Color { ColorId = 1, ColorName = "Kırmızı" });
            ////var result = colorManager.GetById(2);
            ////Console.WriteLine(result.ColorId + " " + result.ColorName);

            ////foreach (var color in colorManager.GetAll())
            ////{
            ////    Console.WriteLine(color.ColorName);
            ////}
        }

        private static void CarTest()
        {
            //CarManager carManager = new CarManager(new EfCarDal());

            ////////carManager.Add(new Car {BrandId = 9, ColorId = 9, CarName = "opo12p", ModelYear = 9, DailyPrice = 201, Description = "op1212op" });
            ////////carManager.Update(new Car {Id=1003,BrandId=9,ColorId=9,CarName="Citroen",ModelYear=2009,DailyPrice=150,Description="Küçük, Rahat"});
            ////////carManager.Delete(new Car {Id = 1002, BrandId = 9, ColorId = 9, CarName = "opop", ModelYear = 9, DailyPrice = 201, Description = "opop" });
            ////////var result = carManager.GetById(4);
            ////////Console.WriteLine(result.Id + " " + result.CarName);

            //var result = carManager.GetCarDetails();
            //foreach (var product in result.Data)
            //{
            //    Console.WriteLine(product.CarName + " " + product.DailyPrice + "TL");
            //}
        }
    }
}
