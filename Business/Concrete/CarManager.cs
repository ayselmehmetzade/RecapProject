using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car car)
        {

            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Ekleme işlemi başarılı!");
            }
            else
            {
                Console.WriteLine("Lütfen tekrar deneyiniz. Açıklamanız 2 karakterden fazla ve günlük fiyat 0 dan büyük olmalıdır!");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Silme işlemi başarılı!");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public List<Car> GetCarsByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }

        public List<Car> GetCarsByDescription(string description)
        {
            return _carDal.GetAll(c => c.Description == description);
        }

        public Car GeyById(int id)
        {
            return _carDal.Get(c => c.Id == id);
        }

        public void Update(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Update(car);
                Console.WriteLine("Güncemele işlemi başarılı!");
            }
            else
            {
                Console.WriteLine("Lütfen tekrar deneyiniz. Açıklamanız 2 karakterden fazla ve günlük fiyat 0 dan büyük olmalıdır!");
            }

        }
    }
}
