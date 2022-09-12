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
            var ruleResult = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (ruleResult != null)
            {
                return new ErrorResult(ruleResult.Message);
            }

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
            // Deleting Image
            var carToBeDeleted = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            if (carToBeDeleted == null)
            {
                return new ErrorResult(Messages.CarImageDoesNotFound);
            }
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

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId)
        {
            var data = _carImageDal.GetAll(cI => cI.CarId == carId);
            if (data.Count == 0)
            {
                data.Add(new CarImage
                {
                    CarId = carId,
                    ImagePath = "C:/Users/omer_/OneDrive/Masaüstü/RentACar/WebAPI/wwwroot/Images/default.jpg"
                });
            }
            return new SuccessDataResult<List<CarImage>>(Messages.TheCarImagesOfTheGivenCarListed, data);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile image, CarImage carImage)
        {
            // Updating Image
            var carToBeUpdated = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            if (carToBeUpdated == null)
            {
                return new ErrorResult(Messages.CarImageDoesNotFound);
            }
            var imageResult = FileHelper.Update(image, carToBeUpdated.ImagePath);
            carImage.ImagePath = imageResult.Message;
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        // Business Rules
        private IResult CheckImageLimitExceeded(int carId)
        {
            var carImagesOfTheCar = _carImageDal.GetAll(p => p.CarId == carId);
            if (carImagesOfTheCar.Count >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();
        }
    }
}