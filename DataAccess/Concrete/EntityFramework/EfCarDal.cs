﻿using Core.DataAccess.EntityFramework;
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
        public List<CarDetailsDto> GetCarDetails(Expression<Func<CarDetailsDto,bool>>filter=null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId
                        
                             select new CarDetailsDto
                             {
                                 CarId=c.Id,
                                 BrandId=b.BrandId,
                                 ColorId=co.ColorId,
                                 CarName=c.CarName,
                                 BrandName=b.BrandName,
                                 ColorName=co.ColorName,
                                 DailyPrice=c.DailyPrice,
                                 Description=c.Description,
                                 ModelYear=c.ModelYear,
                                 CarImages=(from i in context.CarImages where i.CarId==c.Id select i).ToList()

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}

