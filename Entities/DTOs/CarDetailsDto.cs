﻿using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailsDto: IDto
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }

        public string CarName { get; set; }

        public string BrandName { get; set; }

        public string ColorName { get; set; }

        public decimal DailyPrice { get; set; }

        public List<CarImage> CarImages { get; set; }

        public string Description { get; set; }

        public string TypeOfVehicle { get; set; }

        public int ModelYear { get; set; }

    }
}