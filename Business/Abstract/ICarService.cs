
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result.Abstract;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<CarDetailsDto>> GetCarsByBrandId(int brandId);
        IDataResult<List<CarDetailsDto>> GetCarsByColorId(int colorId);
        IDataResult<CarDetailsDto> GetCarDetails(int carId);
        IDataResult<List<CarDetailsDto>> GetCarDetail();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);

    }
}