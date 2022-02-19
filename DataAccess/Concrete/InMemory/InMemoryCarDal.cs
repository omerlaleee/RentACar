using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=1000,Description="Dacia",ModelYear=2014},
                new Car{CarId=2,BrandId=1,ColorId=1,DailyPrice=3000,Description="Volvo",ModelYear=2017},
                new Car{CarId=3,BrandId=2,ColorId=1,DailyPrice=4000,Description="4x4",ModelYear=2014},
                new Car{CarId=4,BrandId=2,ColorId=1,DailyPrice=5000,Description="5x5",ModelYear=2012},
                new Car{CarId=5,BrandId=3,ColorId=1,DailyPrice=9000,Description="Caravelle",ModelYear=2013},
                new Car{CarId=6,BrandId=4,ColorId=1,DailyPrice=10000,Description="Limousine",ModelYear=2011}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car deletedCar = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            if (deletedCar != null)
            {
                _cars.Remove(deletedCar);
            }
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            Car result = _cars.SingleOrDefault(c => c.CarId == id);
            if (result != null)
            {
                return result;
            }
            return new Car { CarId = -1, Description = "-1" };
        }

        public int TotalCarValue()
        {
            return _cars.Count();
        }

        public void Update(Car car)
        {
            Car updatedCar = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            if (updatedCar != null)
            {
                updatedCar.BrandId = car.BrandId;
                updatedCar.ColorId = car.ColorId;
                updatedCar.DailyPrice = car.DailyPrice;
                updatedCar.Description = car.Description;
            }
        }
    }
}
