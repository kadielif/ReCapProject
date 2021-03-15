using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rent)
        {
            var rentCar = _rentalDal.Get(c => c.CarId == rent.CarId && c.ReturnDate<DateTime.Today);
            if (rentCar!=null)
            {
                return new ErrorResult("Bu araç kiralanamaz");
            }
            else
            {
                _rentalDal.Add(rent);
                return new SuccessResult("Araç kiralanmıştır.");
            }
        }

        public IResult Delete(Rental rent)
        {
            _rentalDal.Delete(rent);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.RentalListed);
        }

        public IDataResult<List<RentACarDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentACarDetailDto>>(_rentalDal.RentACarDetail());

        }

        public IDataResult<List<RentACarDetailDto>> GetRentalDetails(int id)
        {
            return new SuccessDataResult<List<RentACarDetailDto>>( _rentalDal.RentACarDetails(id));
        }

        public IResult Update(Rental rent)
        {
            _rentalDal.Update(rent);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
