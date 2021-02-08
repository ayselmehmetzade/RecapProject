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
            //Example2();

            //Example();
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetail())
            {
                Console.WriteLine(car.Description+" / "+ car.BrandName +" / "+ car.ColorName +" / "+ car.DailyPrice);
            }
        }

        private static void Example2()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("Arabaların Açıklamaları");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("----------------");
            Console.WriteLine("Renklerin Adı");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
            Console.WriteLine("-----------------");
            Console.WriteLine("Markaların Adı");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void Example()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
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
            foreach (var c in colorManager.GetAll())
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
