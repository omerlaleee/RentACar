using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

CarManager carManager = new CarManager(new EfCarDal());
ColorManager colorManager = new ColorManager(new EfColorDal());
BrandManager brandManager = new BrandManager(new EfBrandDal());

Color color1 = new Color { ColorName = "White" };
Color color2 = new Color { ColorName = "Black" };
Color color3 = new Color { ColorName = "Blue" };
Color color4 = new Color { ColorName = "Red" };
Color color5 = new Color { ColorName = "Yellow" };
Color color6 = new Color { ColorName = "Grey" };
Color color7 = new Color { ColorName = "Metallic" };

Brand brand1 = new Brand { BrandName = "Mercedes" };
Brand brand3 = new Brand { BrandName = "BMW" };
Brand brand4 = new Brand { BrandName = "Audi" };
Brand brand5 = new Brand { BrandName = "Volkswagen" };
Brand brand6 = new Brand { BrandName = "Toyota" };

Car car1 = new Car { BrandId = 1, ColorId = 1, DailyPrice = 200, ModelYear = 2014, Description = "Mercedes CLA 180" };
Car car2 = new Car { BrandId = 3, ColorId = 1, DailyPrice = 300, ModelYear = 2012, Description = "BMW 5.20 Luxury Line" };
Car car3 = new Car { BrandId = 6, ColorId = 6, DailyPrice = 400, ModelYear = 2018, Description = "Toyota RAV4 Hybrid" };
Car car4 = new Car { BrandId = 1, ColorId = 7, DailyPrice = 150, ModelYear = 2015, Description = "Mercedes GLB 200 AMG" };
Car car5 = new Car { BrandId = 4, ColorId = 1, DailyPrice = 170, ModelYear = 2016, Description = "Audi A3 Sedan" };

// Car_Brand_Color_ManagerTest(carManager, colorManager, brandManager);
// Console.WriteLine();
// EntityFrameworkRepositoryBaseTest(carManager);
// Console.WriteLine();
// DtoTest(carManager);

UserManager userManager = new UserManager(new EfUserDal());
CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
RentalManager rentalManager = new RentalManager(new EfRentalDal());

User user1 = new User { FirstName = "Anıl", LastName = "Abanoz", Email = "anil@gmail.com", Password = "123456" };
User user2 = new User { FirstName = "Eymen", LastName = "Ak", Email = "eymen@gmail.com", Password = "123456" };
User user3 = new User { FirstName = "Abdullah", LastName = "Dereli", Email = "abdullah@gmail.com", Password = "123456" };

// !!!!!!!!!!!ERROR ON DB!!!!!!!!!!
userManager.Add(user1);
userManager.Add(user2);
userManager.Add(user3);

//Customer customer1 = new Customer { UserId = 2, CompanyName = "Company1" };
//Customer customer2 = new Customer { UserId = 3, CompanyName = "Company2" };

//customerManager.Add(customer1);
//customerManager.Add(customer2);

static void Car_Brand_Color_ManagerTest(CarManager carManager, ColorManager colorManager, BrandManager brandManager)
{
    //colorManager.Add(color1);
    //colorManager.Add(color2);
    //colorManager.Add(color3);
    //colorManager.Add(color4);
    //colorManager.Add(color5);
    //colorManager.Add(color6);
    //colorManager.Add(color7);

    //brandManager.Add(brand1);
    //brandManager.Add(brand3);
    //brandManager.Add(brand4);
    //brandManager.Add(brand5);
    //brandManager.Add(brand6);

    //carManager.Add(car1);
    //carManager.Add(car2);
    //carManager.Add(car3);
    //carManager.Add(car4);
    //carManager.Add(car5);

    Car car6 = new Car { BrandId = 4, ColorId = 1, DailyPrice = -10, ModelYear = 2016, Description = "Audi A3 Sedan" };
    Car car7 = new Car { BrandId = 4, ColorId = 1, DailyPrice = 350, ModelYear = 2016, Description = "A" };

    var result1 = carManager.Add(car6);
    if (!result1.Success)
    {
        Console.WriteLine(result1.Message);
    }
    var result2 = carManager.Add(car7);
    if (!result2.Success)
    {
        Console.WriteLine(result2.Message);
    }

    Console.WriteLine();
    var carsWhoseColorIdIsOne = carManager.GetCarsByColorId(1);
    if (carsWhoseColorIdIsOne.Success)
    {
        foreach (var item in carsWhoseColorIdIsOne.Data)
        {
            Console.WriteLine(item.Description + " - Color : " + item.ColorId);
        }
    }
    else
    {
        Console.WriteLine(carsWhoseColorIdIsOne.Message);
    }

    Console.WriteLine();
    var carsWhoseBrandIdIsOne = carManager.GetCarsByBrandId(1);
    if (carsWhoseBrandIdIsOne.Success)
    {
        foreach (var item in carsWhoseColorIdIsOne.Data)
        {
            Console.WriteLine(item.Description + " - Brand : " + item.ColorId);
        }
    }
    else
    {
        Console.WriteLine(carsWhoseBrandIdIsOne.Message);
    }
}

static void EntityFrameworkRepositoryBaseTest(CarManager carManager)
{
    //carManager.Add(new Car { BrandId = 3, ColorId = 2, Description = "Audi A5" });
    //carManager.Update(new Car { CarId = 1003, BrandId = 1, ColorId = 4, DailyPrice = 300, Description = "A" });
    //carManager.Delete(new Car { CarId = 1003 });
}

static void DtoTest(CarManager carManager)
{
    var carDetails = carManager.GetCarDetails();
    if (carDetails.Success)
    {
        foreach (var item in carDetails.Data)
        {
            Console.WriteLine(item.CarName + " / " + item.ColorName + " / " + item.BrandName + " / " + item.DailyPrice);
        }
    }
    else
    {
        Console.WriteLine(carDetails.Message);
    }
}