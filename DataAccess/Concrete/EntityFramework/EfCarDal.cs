﻿using Core.DataAccess.EntityFramework;
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
                             select new CarDetailDto() { BrandName=b.BrandName,CarName=c.BrandId.ToString(),ColorName=color.ColorName};
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
                             where brandId==c.BrandId
                             select new CarDetailDto() { BrandName = b.BrandName, CarName = c.BrandId.ToString(), ColorName = color.ColorName };
                
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
                             select new CarDetailDto() { BrandName = b.BrandName, CarName = c.BrandId.ToString(), ColorName = color.ColorName };

                return result.ToList();
            }
        }
    }
}
