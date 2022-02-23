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

// CarManagerTest(carManager);

// EntityFrameworkRepositoryBaseTest(carManager);

// DtoTest(carManager);

static void CarManagerTest(CarManager carManager)
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

    carManager.Add(car6);
    carManager.Add(car7);

    Console.WriteLine();
    var carsWhoseColorIdIsOne = carManager.GetCarsByColorId(1);
    foreach (var item in carsWhoseColorIdIsOne)
    {
        Console.WriteLine(item.Description + " - Color : " + item.ColorId);
    }

    Console.WriteLine();
    var carsWhoseBrandIdIsOne = carManager.GetCarsByBrandId(1);
    foreach (var item in carsWhoseColorIdIsOne)
    {
        Console.WriteLine(item.Description + " - Brand : " + item.ColorId);
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
    foreach (var item in carDetails)
    {
        Console.WriteLine(item.CarName + " / " + item.ColorName + " / " + item.BrandName + " / " + item.DailyPrice);
    }
}