using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        //List<Car> GetAll(); //Tümünü listele
        IDataResult<List<Car>> GetAll();
        //void Add(Car car); //Ekleme 
        IResult Add(Car car);
        IResult Delete(Car Car); //Silme
        IResult Update(Car car); //Güncelleme
        IDataResult<Car> GetById(int id); //Detayını görüntüle
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<Car>> GetCarsByDailyPrice(decimal min, decimal max);
        IDataResult<List<Car>> GetCarsByDescription(string description);
        IDataResult<List<CarDetailDto>> GetCarDetail();
    }
}
