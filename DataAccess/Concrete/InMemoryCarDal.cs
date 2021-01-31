using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
                new Car{ Id=1, BrandId=1, ColorId=1, ModelYear=2001 ,DailyPrice=10000, Description="Temiz Kullanılmıştır"},
                new Car{ Id=2, BrandId=2, ColorId=2, ModelYear=2005 ,DailyPrice=15000, Description="50 000 kmde"},
                new Car{ Id=3, BrandId=3, ColorId=3, ModelYear=2010 ,DailyPrice=8000, Description="Kazalı Araç"},
                new Car{ Id=4, BrandId=1, ColorId=1, ModelYear=1998 ,DailyPrice=5000, Description="300 000 kmde"},
                new Car{ Id=5, BrandId=3, ColorId=3, ModelYear=2011 ,DailyPrice=20000, Description="Temiz Kullanılmıştır"},
                new Car{ Id=6, BrandId=2, ColorId=1, ModelYear=2003 ,DailyPrice=12000, Description="2.el Araç"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carsDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carsDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carsUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carsUpdate.Id= car.Id;
            carsUpdate.ModelYear = car.ModelYear;
            carsUpdate.Description = car.Description;
            carsUpdate.ColorId = car.ColorId;
            carsUpdate.BrandId = car.BrandId;
            carsUpdate.DailyPrice = car.DailyPrice;
        }
    }
}
