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

            //CustomerAdd();
            //CarAdd();
            //CarDelete();
            //GetCar();
            //JoinThreeTable();
            //GetById(2);
            RentACar();
        }

        private static void RentACar()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rentCar = new Rental() { 
                CarId = 5, 
                CustomerId = 1, 
                RentDate = new DateTime(2020,02,02), 
                ReturnDate = new DateTime(2020,01,03)
            };
            Console.WriteLine(rentalManager.Add(rentCar).Message);

            var result = rentalManager.GetRentalDetails(rentCar.Id);
            foreach (var item in result.Data)
            {
                Console.WriteLine("Marka : "+item.BrandName+ 
                                  "Müşteri: "+ item.CustomerName+
                                  "Kiralama Tarihi: " + item.RentDate.Date+
                                  "Teslim Tarihi:" + item.ReturnDate.Date);

            }


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
                Console.WriteLine(car.Id + " : " + car.Description);
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
        private static void CustomerAdd()
        {
            CustomerManager efCustomerManager = new CustomerManager(new EfCustomerDal());
            Customer customer = new Customer() { UserId = 2, CompanyName = "Company 1" };
            Console.WriteLine(efCustomerManager.Add(customer).Message);

            //UserManager efUserManager = new UserManager(new EfUserDal());
            //User user = new User() { UserId=3,FirstName="Elif",LastName="Kadı",Email="elif_kadi@hotmail.com",Password="1234"};
            //Console.WriteLine(efUserManager.Add(user).Message);

            //CarManager efUserManager = new CarManager(new EfCarDal());
            //Car user = new Car() { Id = 34, BrandId = 1, ColorId = 1, DailyPrice = 400, Description = "Otamatik", ModelYear = 2000 };
            //Console.WriteLine(efUserManager.Add(user).Message);



        }

    }
}
