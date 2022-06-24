using Entities.Concrete;
using System.Collections.Generic;
using Core.Utilities.Result.Abstract;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResult Add(Brand brand);
        IResult Delete(Brand brand);
        IResult Update(Brand brand);
        IDataResult<Brand> GetById(int brandId);
        IDataResult<List<Brand>> GetAll();
    }
}

