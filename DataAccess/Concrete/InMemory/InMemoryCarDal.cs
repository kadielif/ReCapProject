using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car = new List<Car> {
        new Car{Id=1,BrandId=1,ColorId=2,ModelYear=2020,DailyPrice=1300,Description="Otomatik"},
        new Car{Id=2,BrandId=2,ColorId=3,ModelYear=2016,DailyPrice=1000,Description="Manual" },
        new Car{Id=3,BrandId=2,ColorId=3,ModelYear=2016,DailyPrice=1000,Description="Manual" },
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

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetAllCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(Car car)
        {
            return _car.Where(c => car.Id == c.Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate=new Car();
            carToUpdate= _car.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ModelYear = 2017;
            carToUpdate.DailyPrice = 200;
            carToUpdate.Description = "Otomatik";
            carToUpdate.BrandId = 3;
        }
    }
}
