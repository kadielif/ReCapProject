﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetByFilter(int brandId, int colorId);
        List<CarDetailDto> GetAllCarDetails();
        List<CarDetailDto> GetAllByColorIdCarDetails(int colorId);
        List<CarDetailDto> GetAllByBrandIdCarDetails(int brandId);
        List<CarDetailDto> GetCarDetailsById(int id);

    }
}
