using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brand = new List<Brand> { 
            new Brand { Id = 1, BrandName = "Toyoto" }, 
            new Brand { Id = 2, BrandName = "Wolsvagen" }, 
        };
        public void Add(Brand brand)
        {
            _brand.Add(brand);
        }

        public void Delete(Brand brand)
        {
            Brand brandToDelete=_brand.SingleOrDefault(b=>b.Id==brand.Id);
            _brand.Remove(brandToDelete);
        }

        public Brand Get(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll()
        {
            return _brand;
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetById(Brand brand)
        {
            return _brand.Where(b=>b.Id==brand.Id).ToList();
        }

        public void Update(Brand brand)
        {
            Brand brandToDelete = _brand.SingleOrDefault(b => b.Id == brand.Id);
            brandToDelete.BrandName = "Hyndai";
        }
    }
}
