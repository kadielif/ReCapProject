using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetAllCarDetails()
        {
            using (ReCapContext context=new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join color in context.Colors
                             on c.ColorId equals color.Id
                             select new CarDetailDto() { Description = c.Description, Model = c.Model, ModelYear = c.ModelYear, CarId = c.Id, BrandName =b.BrandName, DailyPrice = c.DailyPrice,CarName = c.Model,ColorName=color.ColorName};
                return result.ToList();
            }
        }
        public List<CarDetailDto> GetAllByBrandIdCarDetails(int brandId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join color in context.Colors
                             on c.ColorId equals color.Id
                             where brandId == c.BrandId
                             select new CarDetailDto() { Description = c.Description, Model = c.Model, ModelYear = c.ModelYear, CarId = c.Id, BrandName = b.BrandName, CarName = c.Model, ColorName = color.ColorName, DailyPrice = c.DailyPrice };

                return result.ToList();
            }
        }
        public List<CarDetailDto> GetAllByColorIdCarDetails(int colorId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join color in context.Colors
                             on c.ColorId equals color.Id
                             where colorId == c.BrandId
                             select new CarDetailDto() {Description=c.Description, Model=c.Model,ModelYear=c.ModelYear, CarId = c.Id, BrandName = b.BrandName, CarName = c.Model, ColorName = color.ColorName };


                return result.ToList();
            }
        }
        public List<CarDetailDto> GetCarDetailsById(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join color in context.Colors
                             on c.ColorId equals color.Id
                             where id==c.Id
                             select new CarDetailDto() { Description = c.Description, Model = c.Model, ModelYear = c.ModelYear, CarId =c.Id,  BrandName = b.BrandName, DailyPrice = c.DailyPrice, CarName = c.Model, ColorName = color.ColorName };
                return result.ToList();
            }
        }
    }
}
