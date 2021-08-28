using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=5,DailyPrice=20,Description="asdsafd"},
                new Car{Id=2,BrandId=1,ColorId=2,ModelYear=10,DailyPrice=10,Description="asdsafd"},
                new Car{Id=3,BrandId=1,ColorId=1,ModelYear=3,DailyPrice=5,Description="asdsafd"},
                new Car{Id=4,BrandId=2,ColorId=2,ModelYear=2000,DailyPrice=25,Description="asdsafd"},
                new Car{Id=5,BrandId=2,ColorId=1,ModelYear=3000,DailyPrice=15,Description="asdsafd"},
                new Car{Id=6,BrandId=2,ColorId=2,ModelYear=1500,DailyPrice=8,Description="asdsafd"}
            };
        }
        public void Add(Car entity)
        {
            _cars.Add(entity);
        }

        public void Delete(Car entity)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == entity.Id);

            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(p => p.Id == id).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public void Update(Car entity)
        {
            Car productToUpdate = _cars.SingleOrDefault(p => p.Id == entity.Id);
            productToUpdate.BrandId = entity.BrandId;
            productToUpdate.ColorId = entity.ColorId;
            productToUpdate.ModelYear = entity.ModelYear;
            productToUpdate.DailyPrice = entity.DailyPrice;
            productToUpdate.Description = entity.Description;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
