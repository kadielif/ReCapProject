﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentACarDetailDto> RentACarDetails(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join u in context.Customers
                             on r.CustomerId equals u.UserId
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             where r.Id==id
                             select new RentACarDetailDto() {
                                 BrandName = b.BrandName,
                                 CustomerName = u.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
        public List<RentACarDetailDto> RentACarDetail()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join u in context.Customers
                             on r.CustomerId equals u.UserId
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join user in context.Users
                             on u.UserId equals user.Id
                             select new RentACarDetailDto()
                             {
                                 BrandName = b.BrandName,
                                 CustomerName = user.FirstName+" "+user.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
