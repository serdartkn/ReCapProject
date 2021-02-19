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
            carManager.Add(new Car {BrandId=1,ColorId=1,CarName="Toyota",ModelYear=2020,DailyPrice=450,Description="Deri Koltuk, Cam Tavan"});

        }
    }
}
