using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental); // rent the car
        IResult Update(Rental rental);
        IResult Delete(Rental rental);  
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int rentalId);
        IResult ReceiveCar(Rental rental); // receive the car
    }
}
