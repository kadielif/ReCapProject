using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car = new List<Car> {
        new Car{Id=1,BrandId=1,ModelYear=new DateTime(2016,1,1),DailyPrice=1300,Description="Otomatik"},
        new Car{Id=2,BrandId=2,ModelYear=new DateTime(2020,1,1),DailyPrice=1000,Description="Manual" },
        new Car{Id=3,BrandId=2,ModelYear=new DateTime(2020,1,1),DailyPrice=1000,Description="Manual" },
        };
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete=new Car();
            carToDelete=_car.SingleOrDefault(c=>c.Id==car.Id);
            _car.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetById(Car car)
        {
            return _car.Where(c => car.Id == c.Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate=new Car();
            carToUpdate= _car.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ModelYear = new DateTime(2016, 5, 1);
            carToUpdate.DailyPrice = 200;
            carToUpdate.Description = "Otomatik";
            carToUpdate.BrandId = 3;
        }
    }
}
