using Business.Concrete;
using Core.Entities.Concrete;
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

            //CarDelete(carManager); 

            //CarDetailShow();
            //UserAdd();

            CustomerAdd();
            //RentalAdd();
            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //var result = rentalManager.GetRentalDetails();
            //if (result.Success == true)
            //{
            //    foreach (var rental in result.Data)
            //    {
            //        System.Console.WriteLine(rental.Description + " " + rental.UserName + " " + rental.RentDate);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}

        }

        private static void RentalAdd()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental
            {
                CarId = 3,
                CustomerId = 1,
                RentDate = new DateTime(2021, 3, 5)

            });
            Console.ReadLine();
        }

        private static void CustomerAdd()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
           var result= customerManager.Add(new Customer
            {
                CompanyName = "test",
                UserId = 4
            });
            Console.WriteLine(result.Message);
            Console.ReadLine();

        }

        private static void UserAdd()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User
            {
                FirstName = "Dila",
                LastName = "Saglam",
                Email = "Dila@hotmail.com"
            });
            Console.ReadLine();

        }

        private static void CarDetailShow()
        {
            CarManager carManager = new CarManager(new EfCarDal(), new CustomerManager(new EfCustomerDal()));
            var result = carManager.GetCarDetail();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarDelete(CarManager carManager)
        {

            //silme işlemi
            var data1 = carManager.GetById(1014);
            carManager.Delete(data1.Data);
            var resultSilme = carManager.GetCarDetail();
            if (resultSilme.Success == true)
            {
                foreach (var car in resultSilme.Data)
                {
                    Console.WriteLine(car.Description + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(resultSilme.Message);
            }
        }

        private static void Example2()
        {
            CarManager carManager = new CarManager(new EfCarDal(), new CustomerManager(new EfCustomerDal()));
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("Arabaların Açıklamaları");

            var result = carManager.GetAll();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            Console.WriteLine("----------------");
            Console.WriteLine("Renklerin Adı");
            var result1 = colorManager.GetAll();
            if (result1.Success == true)
            {
                foreach (var color in result1.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result1.Message);
            }

            Console.WriteLine("-----------------");
            Console.WriteLine("Markaların Adı");

            var result2 = brandManager.GetAll();
            if (result2.Success == true)
            {
                foreach (var brand in result2.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result2.Message);
            }

        }

        //private static void Example()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    Console.WriteLine("Bütün Arabaların Açıklamaları");
        //    foreach (var c in carManager.GetAll())
        //    {
        //        Console.WriteLine(c.Description);
        //    }

        //    Console.WriteLine("BrandIdsi 1 olanlar");
        //    foreach (var b in carManager.GetCarsByBrandId(1))
        //    {
        //        Console.WriteLine(b.BrandId);
        //    }

        //    Console.WriteLine("BrandName");
        //    foreach (var b in brandManager.GetAll())
        //    {
        //        Console.WriteLine(b.BrandName);
        //    }



        //    //carManager.Add(new Car { BrandId = 3, ColorId = 3, DailyPrice = 100, ModelYear = "2021", Description = "Manul" });
        //    //brandManager.Add(new Brand { BrandName = "Clio" });
        //    //colormanager.Add(new Color { ColorName = "Yellow" });

        //    Console.WriteLine("Color name");
        //    foreach (var c in colorManager.GetAll())
        //    {
        //        Console.WriteLine(c.ColorName);
        //    }

        //    brandManager.Update(new Brand { BrandId = 5, BrandName = "Test" });
        //    Console.WriteLine("BrandName");
        //    foreach (var b in brandManager.GetAll())
        //    {
        //        Console.WriteLine(b.BrandName);
        //    }
        //}
    }
}
