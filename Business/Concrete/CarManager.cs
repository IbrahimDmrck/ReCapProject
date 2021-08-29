using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandDal _brandDal;
        IColorDal _colorDal;

        public CarManager(ICarDal carDal)
        {
            
            _carDal = carDal;
        }

        public CarManager(IBrandDal brandDal)
        {

            _brandDal = brandDal;
        }

        public CarManager(IColorDal colorDal)
        {

            _colorDal = colorDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)
                _carDal.Add(car);
            else
                Console.WriteLine("Araba ismi en az 2 karakter olmalıdır ve günlük fiyat 0'dan büyük olmalıdır");
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetById(int id)
        {
            return _carDal.GetAll(p => p.Id == id);
        }

        public List<Brand> GetCarsByBrandId(int id)
        {
            return _brandDal.GetAll(p => p.BrandId == id);
        }

        public List<Color> GetCarsByColorId(int id)
        {
          return _colorDal.GetAll(p => p.ColorId == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
