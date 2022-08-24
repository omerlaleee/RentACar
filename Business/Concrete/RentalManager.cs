using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            var rentalHistory = GetRentalsByCarId(rental.CarId);
            foreach (var item in rentalHistory.Data)
            {
                if (item.ReturnDate == null)
                {
                    return new ErrorResult(Messages.CarIsInAlreadyRental);
                }
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IResult Deliver(Rental rental)
        {
            var rentalHistory = GetById(rental.RentalId);
            if (rentalHistory.Data.ReturnDate != null)
            {
                return new ErrorResult(Messages.RentalWasAlreadyDelivered);
            }
            _rentalDal.Deliver(rental);
            return new SuccessResult(Messages.RentalWasDelivered);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(Messages.RentalsListed, _rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(Messages.TheRentalListed, _rentalDal.Get(r => r.RentalId == rentalId));
        }

        public IDataResult<List<Rental>> GetRentalsByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(Messages.TheRentalListed, _rentalDal.GetAll(r => r.CarId == carId));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
