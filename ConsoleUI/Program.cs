using Entities;
using Business;
using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    { 
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager (new InMemoryCarDal());
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Description +" "+ c.DailyPrice);
            }
        }
    }
}
