using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IResult Add(Payment payment)
        {


            var result = BusinessRules.Run(CheckIfThisCardIsAlreadySavedForThisCustomer(payment));
            if (!result.Success)
            {
                return result;
            }
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.PaymentInformationSuccessfullySaved);
           
        }

        public IResult CheckIfThisCardIsAlreadySavedForThisCustomer(Payment payment)
        {
            var result = _paymentDal.Get(p => p.CustomerId == payment.CustomerId && p.CardNumber == payment.CardNumber);
            if (result!=null)
            {
                return new ErrorResult(Messages.ThisCardIsAlreadyRegisteredForThisCustomer);
            }
            return new SuccessResult();

        }

        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult(Messages.Deleted);
   
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(), Messages.Listed);
           
        }

        public IDataResult<List<Payment>> GetAllByCustomerId(int customerId)
        {

            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(p => p.CustomerId == customerId),Messages.Listed);
          
        }

        public IDataResult<Payment> GetById(int id)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(p => p.Id == id), Messages.Geted);

 
        }

        public IResult Pay(Payment payment)
        {
            return new SuccessResult(Messages.PaymentSuccessful);

        }

        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult(Messages.Updated);


        }
    }
}
