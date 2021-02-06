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
          
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Description);
            }
        }
    }
}
