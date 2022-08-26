using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetCustomerById(int customerId);
        IDataResult<Customer> GetCustomerByUserId(int userId);
        IDataResult<List<CustomerDetailDto>> GetCustomersDetails();
        IDataResult<int> Add(Customer customer);
        IResult Delete(int customerId);
        IResult Update(Customer customer);
    }
}
