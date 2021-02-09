using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll(); //Tümünü listele
        void Add(Car car); //Ekleme 
        void Delete(Car Car); //Silme
        void Update(Car car); //Güncelleme
        Car GetById(int id); //Detayını görüntüle
        List<Car> GetCarsByBrandId(int id); 
        List<Car> GetCarsByColorId(int id);
        List<Car> GetCarsByDailyPrice(decimal min, decimal max);
        List<Car> GetCarsByDescription(string description);
        List<CarDetailDto> GetCarDetail();
    }
}
