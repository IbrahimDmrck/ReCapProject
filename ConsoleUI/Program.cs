using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test();
            CarTest();
        }

        private static void Test()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 3, ColorId = 3, DailyPrice = 30, Description = "Ages 20 to 40" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id);
            }

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + " /***/ " + car.BrandName + " /***/ " + car.ColorName + " /***/ " + car.DailyPrice);
            }

        }
    }
}
