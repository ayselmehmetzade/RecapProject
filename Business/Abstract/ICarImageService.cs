using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarImageService
    {
        IResult AddImage(IFormFile file, CarImage image);
        IResult UpdateImage(IFormFile file, CarImage image);
        IResult DeleteImage(CarImage image);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetByCarImages(int carId);
        IDataResult<CarImage> GetById(int imageId);
    }



   
}
