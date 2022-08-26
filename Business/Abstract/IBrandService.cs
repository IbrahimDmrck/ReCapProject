using Entities.Concrete;
using System.Collections.Generic;
using Core.Utilities.Result.Abstract;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<Brand> GetBrandById(int id);
        IDataResult<List<Brand>> GetAll();
        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);
    }
}

