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
    public class RentalMenager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalMenager(IRentalDal rentalDal)
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

        public IResult Deliver(Rental rental)
        {
            _rentalDal.Deliver(rental);
            return new SuccessResult(Messages.RentalWasDelivered);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(Messages.RentalsListed, _rentalDal.GetAll());
        }

        public IDataResult<List<Rental>> GetRentalsByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(Messages.TheRentalListed, _rentalDal.GetAll(r => r.CarId == carId));
        }
    }
}
