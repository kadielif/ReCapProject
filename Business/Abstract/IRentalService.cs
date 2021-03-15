using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental rent);
        IResult Delete(Rental rent);
        IResult Update(Rental rent);
        IDataResult<List<RentACarDetailDto>> GetRentalDetails(int id);
        IDataResult<List<RentACarDetailDto>> GetRentalDetail();

    }
}
