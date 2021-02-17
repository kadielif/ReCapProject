using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            string brandName = brandManager.Get(b => car.BrandId == b.Id).BrandName;
            if (car.DailyPrice>0 && brandName.Length>2)
            {
                _carDal.Add(car);
                Console.WriteLine("car was added to database");
            }
            else
            {
                Console.WriteLine("error");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
           return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.Get(c=>c.Id==id);
        }

        public List<CarDetailDto> GetCarDetail()
        {
            return _carDal.GetAllCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
