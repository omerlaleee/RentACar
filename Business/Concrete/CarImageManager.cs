using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile image, CarImage carImage)
        {
            // Business Rules

            // Adding Image
            var imageResult = FileHelper.Add(image);
            carImage.ImagePath = imageResult.Message;
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var carToBeDeleted = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            FileHelper.Delete(carToBeDeleted.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(Messages.CarImagesListed, _carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(Messages.TheCarImageListed, _carImageDal.Get(cI => cI.CarImageId == carImageId));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile image, CarImage carImage)
        {
            var imageResult = FileHelper.Update(image, carImage.ImagePath);
            carImage.ImagePath = imageResult.Message;
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }
    }
}
