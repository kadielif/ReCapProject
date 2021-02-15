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
            //CarManager carManager = new CarManager(new InMemoryCarDal());
            //BrandManager brandManager = new BrandManager(new InMemoryBrandDal());

            CarManager efCarManager = new CarManager(new EfCarDal());
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Id);
            //}

            //var result = from c in carManager.GetAll()
            //             join b in brandManager.GetAll() on c.BrandId equals b.Id
            //             where c.Id == 2
            //             select b;
            //foreach (var c in result)
            //{
            //    Console.WriteLine(c.BrandName);
            //}

            Console.WriteLine("------------------");


            foreach (var c in efCarManager.GetAll())
            {
                Console.WriteLine(c.Description);
            }

            Car car1 = new Car() { Id = 20, BrandId = 1, ColorId = 2, DailyPrice = 2000, Description = "Otomatik", ModelYear = 2021 };
            Car car2 = new Car() { Id = 21, BrandId = 2, ColorId = 2, DailyPrice = 0, Description = "Otomatik", ModelYear = 2021 };
            Car car3 = new Car() { Id = 22, BrandId = 4, ColorId = 2, DailyPrice = 2000, Description = "Otomatik", ModelYear = 2021 };


            //Çalışır
            efCarManager.Add(car1);
            //Error verir
            efCarManager.Add(car2);
            //Error verir
            efCarManager.Add(car3);

        }
    }
}
