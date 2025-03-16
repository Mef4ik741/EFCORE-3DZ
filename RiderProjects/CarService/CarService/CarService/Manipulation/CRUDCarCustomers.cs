namespace CarService.Manipulation;

public static class CrudCarCustomers
{
    public static void AddCarsCustomers(CarServiceContext context)
    {
        Console.Write("Введите Бренд: "); 
        string brand = Console.ReadLine()!;
                                        
        Console.Write("Введите Модель: "); 
        string model = Console.ReadLine()!;
                                        
        Console.Write("Введите Год выпуска: "); 
        int year = int.Parse(Console.ReadLine()!);
                                        
        Console.Write("Введите ID клиента: "); 
        int customerId = int.Parse(Console.ReadLine()!);
        
        bool carExists = context.Cars.Any(c => c.Model == model && c.CustomerId == customerId);

        if (carExists)
        {
            Console.WriteLine($"Машина с моделью {model} уже есть у этого клиента!");
            return;
        }
        
        var car = new Car
        {
            Brand = brand, 
            Model = model, 
            Year = year,
            CustomerId = customerId,
        };
        
        context.Cars.Add(car);
        context.SaveChanges();

        Console.WriteLine("Машины клиентов добавлены!");
    }

    public static void DeleteCarsCustomers(CarServiceContext context)
    {
        Console.WriteLine("Введите ID машины: ");
        int carId = int.Parse(Console.ReadLine()!);
        
        var car = context.Cars.Find(carId);

        if (car != null)
        {
            context.Cars.Remove(car);
            context.SaveChanges();
        }

        else
        {
            Console.WriteLine("Не найдено");
        }

        Console.WriteLine($"Машина {car!.Model} была удалена!");
    }

    public static void UpdateCarsCustomers(CarServiceContext context)
    {
        Console.Write("Введите ID машины: "); 
        int carId = int.Parse(Console.ReadLine()!);
        
        var car = context.Cars.Find(carId);
        
        if (car != null)
        {
            while (true)
            {
                Console.WriteLine("1 - Изменить бренд");
                Console.WriteLine("2 - Изменить модель");
                Console.WriteLine("3 - Изменить год выпуска");
                Console.WriteLine("4 - Выйти");
                
                int choice = int.Parse(Console.ReadLine()!);

                if (choice == 1)
                {
                    Console.Write("Введите Бренд: "); 
                    string brand = Console.ReadLine()!;               
                    
                    car.Brand = brand;     
                }
                
                else if (choice == 2)
                {
                    Console.Write("Введите Модель: "); 
                    string model = Console.ReadLine()!;               
                    
                    car.Model = model;     
                }
                
                else if (choice == 3)
                {
                    Console.Write("Введите Год выпуска: "); 
                    int year = int.Parse(Console.ReadLine()!);               
                    
                    car.Year = year;     
                }
                
                else if (choice == 4)
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Не правильный ввод");
                    continue;
                }
            }
        }

        else
        {
            Console.WriteLine("Не найдено");
        }

        Console.WriteLine($"Машина {car!.Model} была обновлено!");
    }

    public static void GetAllCarsCustomers(CarServiceContext context)
    {
        var cars = context.Cars.ToList();

        if (cars.Any())
        {
            foreach (var car in cars)
            {
                Console.WriteLine($"ID: {car.Id}\nБренд машины: {car.Brand}, Модель машины: {car.Model} Год выпуска машины {car.Year}, ID Владельца машины: {car.CustomerId}");
            }
        }

        else
        {
            Console.WriteLine("База данных пуста");
        }
    }
}