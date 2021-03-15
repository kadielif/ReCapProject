using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
        List<RentACarDetailDto> RentACarDetails(int id);
        List<RentACarDetailDto> RentACarDetail();
    }
}
