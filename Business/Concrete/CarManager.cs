using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
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

        [SecuredOperation("admin,product.add")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            using (ReCapContext context = new ReCapContext())
            {
                if (car.DailyPrice > 0 && context.Brands.SingleOrDefault(b => b.Id == car.BrandId).BrandName.Length > 2 )
                {
                    _carDal.Add(car);
                    return new SuccessResult(Messages.CarAdded);
                }
                return new ErrorResult(Messages.CarAddedError);
            }
        }

        [CacheAspect]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarDeleted);
        }
        [PerformanceAspect(5)]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails());
        }
        public IDataResult<List<CarDetailDto>> GetCarDetailsById(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsById(id));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllByBrandIdCarDetails(id));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllByColorIdCarDetails(id));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

 
    }

}
