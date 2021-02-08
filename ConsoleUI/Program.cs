using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramewrok;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colormanager = new ColorManager(new EfColorDal());
            
            Console.WriteLine("Bütün Arabaların Açıklamaları");
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Description);
            }

            Console.WriteLine("BrandIdsi 1 olanlar");
            foreach (var b in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(b.BrandId);
            }

            Console.WriteLine("BrandName");
            foreach (var b in brandManager.GetAll())
            {
                Console.WriteLine(b.BrandName);
            }



            //carManager.Add(new Car { BrandId = 3, ColorId = 3, DailyPrice = 100, ModelYear = "2021", Description = "Manul" });
            //brandManager.Add(new Brand { BrandName = "Clio" });
            //colormanager.Add(new Color { ColorName = "Yellow" });

            Console.WriteLine("Color name");
            foreach (var c in colormanager.GetAll())
            {
                Console.WriteLine(c.ColorName);
            }

            brandManager.Update(new Brand { BrandId = 5, BrandName = "Test" });
            Console.WriteLine("BrandName");
            foreach (var b in brandManager.GetAll())
            {
                Console.WriteLine(b.BrandName);
            }

           
        }
    }
}
