using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemoryDal;
using Entities.Concrete;

CarManager carManager = new CarManager(new EfCarDal());
BrandManager brandManager = new BrandManager(new EfBrandDal());
ColorManager colorManager = new ColorManager(new EfColorDal());

//// 15.08.2022 - 23:40

// Core Layer and Dtos added to the project.
foreach (var item in carManager.GetCarDetails())
{
    Console.WriteLine(item.BrandName + " / " + item.CarName + " / " + item.ColorName + " / " + item.DailyPrice);
}

//// 15.08.2022 - 23:40

//////////////////////////////////////////////////////////////////////////////////////////////////////////

//// 15.08.2022 - 17:33

//brandManager.Add(new Brand { BrandName = "Volvo" });
//colorManager.Add(new Color { ColorName = "Black" });
//colorManager.Add(new Color { ColorName = "White" });
//carManager.Add(new Car { CarName = "S60", BrandId = 1, ColorId = 1, DailyPrice = 100, Description = "No Accident", ModelYear = 2012 });
//carManager.Add(new Car { CarName = "S90", BrandId = 1, ColorId = 2, DailyPrice = 200, Description = "No Accident", ModelYear = 2010 });

//brandManager.Add(new Brand { BrandName = "Mercedes" });
//carManager.Add(new Car { CarName = "C180", BrandId = 2, ColorId = 1, DailyPrice = 300, Description = "No Accident", ModelYear = 2013 });
//carManager.Add(new Car { CarName = "C200", BrandId = 2, ColorId = 2, DailyPrice = 150, Description = "No Accident", ModelYear = 2011 });

//foreach (var item in carManager.GetAll())
//{
//    Console.WriteLine(item.CarName + " / Brand Id : " + item.BrandId + " / Color Id : " + item.ColorId);
//}
//Console.WriteLine("------------------");
//foreach (var item in carManager.GetCarsByBrandId(1))
//{
//    Console.WriteLine(item.CarName + " / Brand Id : " + item.BrandId);
//}
//Console.WriteLine("------------------"); 
//foreach (var item in carManager.GetCarsByColorId(2))
//{
//    Console.WriteLine(item.CarName + " / Color Id : " + item.ColorId);
//}
//Console.WriteLine("------------------");

//carManager.Add(new Car { CarName = "BBB", BrandId = 1, ColorId = 2, DailyPrice = 0, Description = "No Accident", ModelYear = 2010 });


//// 15.08.2022 - 17:33

//////////////////////////////////////////////////////////////////////////////////////////////////////////

//// 11.08.2022 - 22:22


// CarManager carManager = new CarManager(new InMemoryCarDal());

//foreach (var item in carManager.GetAll())
//{
//    Console.WriteLine(item.Description);
//}

//Console.WriteLine("-----------------------------------");

//Console.WriteLine(carManager.GetById(1).Description);

//Console.WriteLine("-----------------------------------");

//carManager.Add(new Car { CarId = 6, Description = "Volvo S60" });

//foreach (var item in carManager.GetAll())
//{
//    Console.WriteLine(item.Description);
//}

//Console.WriteLine("-----------------------------------");

//carManager.Delete(new Car { CarId = 2 });

//foreach (var item in carManager.GetAll())
//{
//    Console.WriteLine(item.Description);
//}

//Console.WriteLine("-----------------------------------");

//carManager.Update(new Car { CarId = 6, Description = "Volvo S60 Updated", DailyPrice = 900 });

//foreach (var item in carManager.GetAll())
//{
//    Console.WriteLine(item.Description);
//}

//Console.WriteLine("-----------------------------------");

//Console.WriteLine("DailyPrice of the 6th Car : " + carManager.GetById(6).DailyPrice);

//// 11.08.2022 - 22:22