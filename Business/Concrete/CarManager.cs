using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        public IResult Add(Car car)
        {
            //if (car.Description.Length >= 2 && car.DailyPrice > 0)
            //{
            //    _carDal.Add(car);
            //    Console.WriteLine("Ekleme işlemi başarılı!");
            //}
            //else
            //{
            //    Console.WriteLine("Lütfen tekrar deneyiniz. Açıklamanız 2 karakterden fazla ve günlük fiyat 0 dan büyük olmalıdır!");
            //}
            if (car.Description.Length<=2 && car.DailyPrice<0)
            {
                return new ErrorResult(Messages.CarInvalid);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            //Console.WriteLine("Silme işlemi başarılı!");
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            //if (DateTime.Now.Hour == 23)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}

            return new SuccessDataResult<List<Car>>( _carDal.GetAll(),Messages.Added);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>( _carDal.GetCarDetail());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<Car>> GetCarsByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<List<Car>> GetCarsByDescription(string description)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c => c.Description == description));
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car> (_carDal.Get(c => c.Id == id));
        }

        public IResult Update(Car car)
        {
            //if (car.Description.Length >= 2 && car.DailyPrice > 0)
            //{
            //    _carDal.Update(car);
            //    Console.WriteLine("Güncemele işlemi başarılı!");
            //}
            //else
            //{
            //    Console.WriteLine("Lütfen tekrar deneyiniz. Açıklamanız 2 karakterden fazla ve günlük fiyat 0 dan büyük olmalıdır!");
            //}
            if (car.Description.Length <= 2 && car.DailyPrice < 0)
            {
                return new ErrorResult(Messages.CarInvalid2);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);

        }
    }
}
