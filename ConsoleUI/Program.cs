using Entities;
using Business;
using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramerwork;

namespace ConsoleUI
{
    class Program
    { 
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager (new EfCarDal());
            
            carManager.Add(new Car {BrandId=3,ColorId=5,CarName="BMW",ModelYear=2019,DailyPrice=480,Description="Spor"});

            foreach (var product in carManager.GetAll())
            {
                Console.WriteLine(product.CarName + " " + product.DailyPrice + "TL");
            }

        }
    }
}
