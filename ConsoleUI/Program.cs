using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
          
            carManager.Add(new Car {Id=7, BrandId=2, ColorId=3, ModelYear=1994, DailyPrice=14000, Description="Nostalji Model" });
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Id);
            }
        }
    }
}
