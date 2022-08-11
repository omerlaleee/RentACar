using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemoryDal
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ModelId=1,ColorId=1,DailyPrice=100,Description="Volvo S90"},
                new Car{CarId=2,BrandId=1,ModelId=2,ColorId=2,DailyPrice=200,Description="BMW"},
                new Car{CarId=3,BrandId=2,ModelId=1,ColorId=3,DailyPrice=300,Description="Woswogen"},
                new Car{CarId=4,BrandId=2,ModelId=2,ColorId=2,DailyPrice=300,Description="Mustang"},
                new Car{CarId=5,BrandId=1,ModelId=3,ColorId=1,DailyPrice=500,Description="Ferrari"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            if (carToDelete != null)
            {
                _cars.Remove(carToDelete);
            }
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int carId)
        {
            return _cars.SingleOrDefault(c => c.CarId == carId);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            if (carToUpdate != null)
            {
                carToUpdate.GetType().GetProperties().ToList().ForEach(pForOldObject =>
                {
                    car.GetType().GetProperties().ToList().ForEach(pForNewObject =>
                    {
                        if (pForOldObject.Name == pForNewObject.Name)
                        {
                            pForOldObject.SetValue(carToUpdate, pForNewObject.GetValue(car));
                        }
                    });
                });
            }
        }
    }
}