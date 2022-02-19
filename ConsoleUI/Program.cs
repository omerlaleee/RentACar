using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

CarManager carManager = new CarManager(new InMemoryCarDal());

Console.WriteLine("GetAll\n");
var allCars = carManager.GetAll();
foreach (var item in allCars)
{
    Console.WriteLine(item.CarId + " " + item.Description);
}


Console.WriteLine("\nAdding\n");
Car newCar = new Car { CarId = 7, BrandId = 1, ColorId = 3, DailyPrice = 700, Description = "SLX", ModelYear = 2008 };
carManager.Add(newCar);
allCars = carManager.GetAll();
foreach (var item in allCars)
{
    Console.WriteLine(item.CarId + " " + item.Description);
}

Console.WriteLine("\nDeleting\n");
Car deletedCar = new Car { CarId = 3 };
carManager.Delete(deletedCar);
allCars = carManager.GetAll();
foreach (var item in allCars)
{
    Console.WriteLine(item.CarId + " " + item.Description);
}

Console.WriteLine("\nGetById\n");
Car getById = carManager.GetById(7);
Console.WriteLine(getById.CarId + " " + getById.Description);


Console.WriteLine("\nUpdating\n");
Car updatedCar = new Car { CarId = 7, BrandId = 1, ColorId = 3, DailyPrice = 700, Description = "Updated SLXXX", ModelYear = 2008 };
carManager.Update(updatedCar);
allCars = carManager.GetAll();
foreach (var item in allCars)
{
    Console.WriteLine(item.CarId + " " + item.Description);
}


Console.WriteLine("\nSecond Adding\n");
Car newCar2 = new Car { CarId = 8, BrandId = 3, ColorId = 1, DailyPrice = 1700, Description = "BMW", ModelYear = 2020 };
carManager.Add(newCar2);
allCars = carManager.GetAll();
foreach (var item in allCars)
{
    Console.WriteLine(item.CarId + " " + item.Description);
}

Console.WriteLine("\nSecond Deleting\n");
Car deletedCar2 = new Car { CarId = 3 };
carManager.Delete(deletedCar2);
allCars = carManager.GetAll();
foreach (var item in allCars)
{
    Console.WriteLine(item.CarId + " " + item.Description);
}