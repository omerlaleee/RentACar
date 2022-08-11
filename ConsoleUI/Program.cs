using Business.Concrete;
using DataAccess.Concrete.InMemoryDal;
using Entities.Concrete;

CarManager carManager = new CarManager(new InMemoryCarDal());

foreach (var item in carManager.GetAll())
{
    Console.WriteLine(item.Description);
}

Console.WriteLine("-----------------------------------");

Console.WriteLine(carManager.GetById(1).Description);

Console.WriteLine("-----------------------------------");

carManager.Add(new Car { CarId = 6, Description = "Volvo S60" });

foreach (var item in carManager.GetAll())
{
    Console.WriteLine(item.Description);
}

Console.WriteLine("-----------------------------------");

carManager.Delete(new Car { CarId = 2 });

foreach (var item in carManager.GetAll())
{
    Console.WriteLine(item.Description);
}

Console.WriteLine("-----------------------------------");

carManager.Update(new Car { CarId = 6, Description = "Volvo S60 Updated", DailyPrice = 900 });

foreach (var item in carManager.GetAll())
{
    Console.WriteLine(item.Description);
}

Console.WriteLine("-----------------------------------");

Console.WriteLine("DailyPrice of the 6th Car : " + carManager.GetById(6).DailyPrice);

// 11.08.2022 - 22:22