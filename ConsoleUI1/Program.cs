using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarAdd();
            //CarDelete();
            GetCar();
            //JoinThreeTable();
            //GetById(2);
        }

        private static void JoinThreeTable()
        {
            CarManager efCarManager = new CarManager(new EfCarDal());
            foreach (var c in efCarManager.GetCarDetail().Data)
            {
                Console.WriteLine(c.CarName + " : " + c.BrandName);
            }
        }
        private static void GetById(int id)
        {
            CarManager efCarManager = new CarManager(new EfCarDal());
            Console.WriteLine(efCarManager.GetById(id).Data.Description);
        }

        private static void CarUpdate()
        {
            CarManager efCarManager = new CarManager(new EfCarDal());
            efCarManager.Update(new Car() { Id = 23, BrandId = 1, ColorId = 2, DailyPrice = 2000, Description = "Manual", ModelYear = 2021 });
        }

        private static void CarDelete()
        {
            CarManager efCarManager = new CarManager(new EfCarDal());
            efCarManager.Delete(new Car() { Id = 23, BrandId = 1, ColorId = 2, DailyPrice = 2000, Description = "Otomatik", ModelYear = 2021 });
        }

        private static void GetCar()
        {
            CarManager efCarManager = new CarManager(new EfCarDal());
            foreach (var car in efCarManager.GetAll().Data)
            {
                Console.WriteLine(car.Id+" : "+car.Description);
            }
        }

        private static void CarAdd()
        {
            CarManager efCarManager = new CarManager(new EfCarDal());
            Car car1 = new Car() { Id = 32, BrandId = 1, ColorId = 2, DailyPrice = 2000, Description = "Otomatik", ModelYear = 2021 };
            //Car car2 = new Car() { Id = 21, BrandId = 2, ColorId = 2, DailyPrice = 0, Description = "Otomatik", ModelYear = 2021 };
     
            //Çalışır
            
            Console.WriteLine(efCarManager.Add(car1).Message);
            //Error verir
            //efCarManager.Add(car2);
        }
    }
}
