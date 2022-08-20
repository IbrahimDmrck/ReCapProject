using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{

    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetail(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from car in filter == null ? context.Cars : context.Cars.Where(filter)
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             select new CarDetailsDto
                             {
                                 CarId = car.Id,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 CarName = car.CarName,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 TypeOfVehicle = car.TypeOfVehicle,
                                 CarImages = context.CarImages.Where(ci => ci.CarId == car.Id).ToList()
                             };
                return result.ToList();
            }
        }

        public CarDetailsDto GetCarDetails(Expression<Func<Car, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from car in context.Cars.Where(filter)
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             select new CarDetailsDto
                             {
                                 CarId = car.Id,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 CarName = car.CarName,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 TypeOfVehicle = car.TypeOfVehicle,
                                 CarImages = context.CarImages.Where(ci => ci.CarId == car.Id).ToList()
                             };
                return result.SingleOrDefault();
            }
        }
    }
}

