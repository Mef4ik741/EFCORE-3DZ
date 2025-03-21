using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Channels;
using System.Xml;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Logging;

namespace ConsoleApp5;

class Program
{
    private static string connectionString = "Data Source=localhost; Initial Catalog=CarsDBW; Trust Server Certificate=true; Integrated Security=True;";

    
    static void Main()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(connectionString)
            .EnableSensitiveDataLogging()
            .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
            .Options;
        
        using (var context = new ApplicationDbContext())
        {
            /*var dealers = context.Dealers
                .Include(d => d.Cars) 
                .ToList();

            foreach (var dealer in dealers)
            {
                Console.WriteLine($"Дилер: {dealer.Name}, Локация: {dealer.Location}");

                foreach (var car in dealer.Cars)
                {
                    Console.WriteLine($"  - {car.Make} {car.Model} ({car.Year})");
                }
            }
            
            var cars = context.Cars.FirstOrDefault(c => c.Id == 1);

            if (cars != null)
            {
                context.Entry(cars).Reference(c => c.Dealer).Load();

                Console.WriteLine($"Машина: {cars.Make} {cars.Model} ({cars.Year})");
                Console.WriteLine($"Дилер: {cars.Dealer.Name}, Локация: {cars.Dealer.Location}");
            }
            
            string make = "Toyota";

            var crs = context.Cars
                .FromSqlRaw("SELECT * FROM Cars WHERE Make = {0}", make)
                .ToList();

            foreach (var car in crs)
            {
                Console.WriteLine($"Машина: {car.Make} {car.Model} ({car.Year})");
            }*/

            while (true)
            {
                Console.WriteLine("1 - Работа с Машинами");
                Console.WriteLine("2 - Работа с Клиентами");
                Console.WriteLine("3 - Работа с Диллерами");
                Console.WriteLine("4 - Выйти из программы");
                
                int choice = int.Parse(Console.ReadLine()!);

                if (choice == 1)
                {
                    while (true)
                    {
                        Console.WriteLine("1 - Добавить машину");
                        Console.WriteLine("2 - Удалить машину");
                        Console.WriteLine("3 - Обновить машину");
                        Console.WriteLine("4 - Показать машины на консоль");
                        Console.WriteLine("5 - Выйти из цикла");
                        
                        int choice2 = int.Parse(Console.ReadLine()!);

                        if (choice2 == 1)
                        {
                            Console.Write("Введите марку машины: ");
                            string make = Console.ReadLine()!;
                            
                            Console.Write("Введите модель машины: ");
                            string model = Console.ReadLine()!;
                            
                            Console.Write("Введите год выпуска: ");
                            int year = int.Parse(Console.ReadLine()!);

                            Console.WriteLine("Введите ID диллера: ");
                            int id = int.Parse(Console.ReadLine()!);
                            
                            var newCar = new Car { Make = make, Model = model, Year = year };
                            CarManipulation.AddCar(context, newCar, id);
                        }
                        
                        else if (choice2 == 2)
                        {
                            Console.Write("Введите ID машины, которую хотите удалить: ");
                            int carId = int.Parse(Console.ReadLine()!);
                        
                            CarManipulation.DeleteCar(context, carId);
                        }
                
                        else if (choice2 == 3)
                        {
                            Console.Write("Введите ID машины, которую хотите обновить: ");
                            int carId = int.Parse(Console.ReadLine()!);
                            
                            Console.Write("Введите новую марку: ");
                            string newMake = Console.ReadLine()!;
                            
                            Console.Write("Введите новую модель: ");
                            string newModel = Console.ReadLine()!;
                            
                            Console.Write("Введите новый год выпуска: ");
                            int newYear = int.Parse(Console.ReadLine()!);
                            
                            CarManipulation.UpdateCar(context, carId, newMake, newModel, newYear);
                        }
                        
                        else if (choice2 == 4)
                        {
                            CarManipulation.GetAllCars(context);
                        }
                        
                        else if (choice2 == 5)
                        {
                            break;
                        }
                    }
                }
                
                else if (choice == 2)
                {
                    while (true)
                    {
                        Console.WriteLine("1 - Добавить Клиента");
                        Console.WriteLine("2 - Удалить Клиента");
                        Console.WriteLine("3 - Обновить Клиента");
                        Console.WriteLine("4 - Показать Клиента на консоль");
                        Console.WriteLine("5 - Выйти из цикла");
                        
                        int choice3 = int.Parse(Console.ReadLine()!);

                        if (choice3 == 1)
                        {
                            Console.WriteLine("Введите имя клиента: ");
                            string nameCustomer = Console.ReadLine()!;
                            
                            var customer = new Customer { Name = nameCustomer };
                            
                            CustomerManipulation.AddCustomers(context, customer);
                        }
                        
                        else if (choice3 == 2)
                        {
                            Console.WriteLine("Введите ID Клиента: ");
                            int customerId = int.Parse(Console.ReadLine()!);
                            
                            CustomerManipulation.DeleteCustomer(context, customerId);
                        }
                        
                        else if (choice3 == 3)
                        {
                            Console.WriteLine("Введите ID Клиента: ");
                            int customerId = int.Parse(Console.ReadLine()!);

                            Console.WriteLine("Введите имя клиента: ");
                            string nameCustomer = Console.ReadLine()!;

                            
                            CustomerManipulation.UpdateCustomer(context, customerId, nameCustomer);
                        }
                        
                        else if (choice3 == 4)
                        {
                            CustomerManipulation.GetallCustomers(context);
                        }
                        
                        else if (choice3 == 5)
                        {
                            break;
                        }
                    }
                }
                
                else if (choice == 3)
                {
                    while (true)
                    {
                        Console.WriteLine("1 - Добавить Диллера");
                        Console.WriteLine("2 - Удалить Диллера");
                        Console.WriteLine("3 - Обновить Диллера");
                        Console.WriteLine("4 - Показать Диллера на консоль");
                        Console.WriteLine("5 - Выйти из цикла");
                        int choice4 = int.Parse(Console.ReadLine()!);

                        if (choice4 == 1)
                        {
                            Console.WriteLine("Введите имя Диллера: ");
                            string nameDealer = Console.ReadLine()!;
                            
                            Console.WriteLine("Введите локацию диллера");
                            string location = Console.ReadLine()!;
                            
                            var dealer = new Dealer { Name = nameDealer , Location = location };
                            
                            DealerManipulation.AddDealer(context,dealer);
                        }
                        
                        else if (choice4 == 2)
                        {
                            Console.WriteLine("Введите ID диллера: ");
                            int dealerId = int.Parse(Console.ReadLine()!);
                            
                            DealerManipulation.DeleteDealer(context, dealerId);
                        }
                        
                        else if (choice4 == 3)
                        {
                            Console.WriteLine("Введите ID диллера: ");
                            int dealerId = int.Parse(Console.ReadLine()!);
                            
                            Console.WriteLine("Введите имя Диллера: ");
                            string nameDealer = Console.ReadLine()!;
                            
                            Console.WriteLine("Введите локацию диллера");
                            string location = Console.ReadLine()!;
                            
                            DealerManipulation.UpdateDealer(context, dealerId, nameDealer, location);
                        }
                        
                        else if (choice4 == 4)
                        {
                            DealerManipulation.GetAllDealers(context);
                        }
                        
                        else if (choice4 == 5)
                        {
                            break;
                        }
                    }
                }
                
                else if (choice == 4)
                {
                    break;
                }
            }
        }
    }
}