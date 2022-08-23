using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;
        ICarService _carService;
        ICustomerService _customerService;

        public RentalManager(IRentalDal rentalDal,ICarService carService,ICustomerService customerService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _customerService = customerService;
        }
       

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = RulesForAdding(rental);
            if (!result.Success)
            {
                return result;
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetDetails());
          
        }

        public IResult RulesForAdding(Rental rental)
        {
            return BusinessRules.Run(
                CheckIfThisCarIsRentedAtALaterDateWhileReturnDateIsNull(rental),
                CheckIfThisCarHasBeenReturned(rental),
                CheckIfThisCarIsAlreadyRentedInSelectedDateRange(rental),
                CheckIfRentDateIsBeforeToday(rental.RentDate),
                CheckIfReturnDateIsBeforeRentDate(rental.ReturnDate, rental.RentDate));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        private IResult CheckIfThisCarHasBeenReturned(Rental rental)
        {
            var result = _rentalDal.Get(p => p.CarId == rental.CarId && p.ReturnDate == null);
            if (result!=null)
            {
                if (rental.ReturnDate==null || rental.ReturnDate>result.RentDate)
                {
                    return new ErrorResult(Messages.CarIsOnRent);
                }
            }
            return new SuccessResult();
        }

        private IResult CheckIfThisCarIsAlreadyRentedInSelectedDateRange(Rental rental)
        {
            var result = _rentalDal.Get(r =>
                r.CarId == rental.CarId
                && (r.RentDate.Date == rental.RentDate.Date
                || (r.RentDate.Date < rental.RentDate.Date
                && (r.ReturnDate == null || ((DateTime)r.ReturnDate).Date > rental.RentDate.Date))));

            if (result != null)
                return new ErrorResult(Messages.ThisCarIsAlreadyRentedInSelectedDateRange);

            return new SuccessResult();
        }

        private IResult CheckIfThisCarIsRentedAtALaterDateWhileReturnDateIsNull(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId && rental.ReturnDate == null && r.RentDate.Date > rental.RentDate);
            if (result.Any()) return new ErrorResult(Messages.ReturnDateCannotBeLeftBlankAsThisCarWasAlsoRentedAtALaterDate);

            return new SuccessResult();
        }

        //private IResult CheckIfCustomerIsFindeksPointIsSufficientForThisCar(int carId, int customerId)
        //{
        //    var carResult = _carService.GetById(carId);
        //    if (!carResult.Success) return new ErrorResult(carResult.Message);

        //    var customerResult = _customerService.GetById(customerId);
        //    if (!customerResult.Success) return new ErrorResult(customerResult.Message);

        //    if (carResult.Data.FindeksPoint > customerResult.Data.FindeksPoint)
        //        return new ErrorResult(Messages.CustomerFindeksPointIsNotEnoughForThisCar);

        //    return new SuccessResult();
        //}

        private IResult CheckIfRentDateIsBeforeToday(DateTime rentDate)
        {
            if (rentDate.Date < DateTime.Now.Date)
                return new ErrorResult(Messages.RentalDateCannotBeBeforeToday);

            return new SuccessResult();
        }

        private IResult CheckIfReturnDateIsBeforeRentDate(DateTime? returnDate, DateTime rentDate)
        {
            if (returnDate != null)
                if (returnDate < rentDate)
                    return new ErrorResult(Messages.ReturnDateCannotBeEarlierThanRentDate);

            return new SuccessResult();
        }
    }
}
