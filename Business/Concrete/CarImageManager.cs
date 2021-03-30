using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        const string ImageFolder = "Images";

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult AddImage(IFormFile file, CarImage image)
        {
            IResult result = BusinessRules.Run(ImageCountControl(image));

            if (result!=null)
            {
                return new ErrorResult(result.Message);
            }

            var imageResult = FileUploadHelper.Upload(file);

            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            image.ImagePath = imageResult.Message;
            _carImageDal.Add(image);
            return new SuccessResult(Messages.ImageAdded);
        }
    
        public IResult DeleteImage(CarImage imageq)
        {
            var image = _carImageDal.Get(c => c.Id == imageq.Id);
            if (image == null)
            {
                return new ErrorResult("Image not found");
            }
            FileUploadHelper.Delete(image.ImagePath);
            _carImageDal.Delete(image);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ImageList);
        }

        public IDataResult<List<CarImage>> GetByCarImages(int carId)
        {            
            return new SuccessDataResult<List<CarImage>>((CheckCarImagesExists(carId)), Messages.ListedByCarId);
        }

        public IDataResult<CarImage> GetById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.GetById(imageId), Messages.ImageList);
        }

        public IResult UpdateImage( IFormFile file, CarImage image)
        {
            var isImage = _carImageDal.Get(c => c.Id == image.Id);
            if (isImage == null)
            {
                return new ErrorResult("Image not found");
            }

            var updatedFile = FileUploadHelper.Update(file, isImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            image.ImagePath = updatedFile.Message;
            image.Date = DateTime.Now;
            _carImageDal.Update(image);
            return new SuccessResult(Messages.ImageUpdated);
        }

        private IResult ImageCountControl(CarImage image)
        {
            List<CarImage> getImages = _carImageDal.GetAll(p => p.CarId == image.CarId);
            if (getImages.Count >= 5)
            {
                return new ErrorResult(Messages.CarImageCountError);
            }
            return new SuccessResult();
        }
        private List<CarImage> CheckCarImagesExists(int carId)
        {
            bool check = _carImageDal.Any(x => x.CarId == carId);
            string path = ImageFolder + @"\deneme.jpg";
            if (!check)
            {
                List<CarImage> carImage = new List<CarImage>()
                {
                    new CarImage {CarId = carId , ImagePath = path}
                };
                return carImage;
            }
            return _carImageDal.GetAll(c => c.CarId == carId);
        }

      
    }
}
