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
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Colors
                             join car in context.Cars
                             on c.ColorId equals car.ColorId
                             join b in context.Brands
                             on car.BrandId equals b.BrandId
                             select new CarDetailDto
                             {
                              CarName=car.CarName,
                              BrandName=b.BrandName,
                              ColorName=c.ColorName,
                              DailyPrice=car.DailyPrice

                             };
                return result.ToList();
            }
        }
    }
}

