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
        public IResult Add(Rental rental)   // rent the car to rentals
        {
            var allRentals = _rentalDal.GetAll(r => r.ReturnDate == null);
            foreach (var item in allRentals)
            {
                if (item.CarId == rental.CarId)
                {
                    return new ErrorResult(Messages.CarCanNotRented);
                }
            }
            rental.RentDate = DateTime.UtcNow;
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult ReceiveCar(Rental rental)    // receive the car from rentals
        {
            var receivedRental = _rentalDal.Get(r => r.RentalId == rental.RentalId);
            if (receivedRental != null && receivedRental.ReturnDate == null)
            {
                receivedRental.ReturnDate = DateTime.UtcNow;
                _rentalDal.Update(receivedRental);
                return new SuccessResult(Messages.CarReceived);
            }
            else if (receivedRental.ReturnDate != null)
            {
                return new ErrorResult(Messages.CarWasAlreadyReceived);
            }
            else
            {
                return new ErrorResult(Messages.CouldNotFoundAnyRentalAccordingToTheseInformations);
            }
        }

        public IResult Delete(Rental rental)    // delete the rental data from rentals database table
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId), Messages.RentalListedById);
        }
    }
}
