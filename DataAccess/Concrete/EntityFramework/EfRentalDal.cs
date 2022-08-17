using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, DatabaseContext>, IRentalDal
    {
        public void Deliver(Rental rental)
        {
            using (DatabaseContext context = new())
            {
                var rentalToBeDelivered = context.Set<Rental>().SingleOrDefault(r => r.RentalId == rental.RentalId);
                rentalToBeDelivered.ReturnDate = DateTime.Now;
                context.SaveChanges();
            }
        }
    }
}
