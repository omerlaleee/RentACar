using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemoryDal;
using Entities.Concrete;


CarManager carManager = new CarManager(new EfCarDal());
BrandManager brandManager = new BrandManager(new EfBrandDal());
ColorManager colorManager = new ColorManager(new EfColorDal());
UserManager userManager = new UserManager(new EfUserDal());
CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
RentalManager rentalMenager = new RentalManager(new EfRentalDal(), new CarManager(new EfCarDal()), new CustomerManager(new EfCustomerDal()));

//var result = rentalMenager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = null });
//var result = rentalMenager.GetAll();
//foreach (var item in result.Data)
//{
//    Console.WriteLine(item.RentDate);
//}
var result = rentalMenager.Deliver(new Rental { RentalId = 7 });

Console.WriteLine(result.Message);
