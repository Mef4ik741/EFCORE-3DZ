namespace ConsoleApp5;

public static class CarManipulation
{
    public static void AddCar(ApplicationDbContext context, Car car, int dealerId)
    {
        var dealer = context.Dealers.FirstOrDefault(d => d.Id == dealerId);
        if (dealer == null)
        {
            Console.WriteLine("Дилер с таким ID не существует.");
            return;
        }

        car.Dealer = dealer;
        context.Cars.Add(car);
        context.SaveChanges();
        Console.WriteLine($"Машина {car.Make} {car.Model} ({car.Year}) добавлена в базу данных.");
    }

    
    public static void UpdateCar(ApplicationDbContext context, int carId, string newMake, string newModel, int newYear)
    {
        var car = context.Cars.FirstOrDefault(c => c.Id == carId);
        
        if (car != null)
        {
            car.Make = newMake;
            car.Model = newModel;
            car.Year = newYear;
            context.SaveChanges();
            Console.WriteLine($"Машина {carId} обновлена.");
        }
        else
        {
            Console.WriteLine("Машина не найдена.");
        }
    }
    
    public static void DeleteCar(ApplicationDbContext context, int carId)
    {
        var car = context.Cars.FirstOrDefault(c => c.Id == carId);
        
        if (car != null)
        {
            context.Cars.Remove(car);
            context.SaveChanges();
            Console.WriteLine($"Машина {carId} удалена из базы данных.");
        }
        else
        {
            Console.WriteLine("Машина не найдена.");
        }
    }

    public static void GetAllCars(ApplicationDbContext context)
    {
        var cars = context.Cars.ToList();
        
        if (cars.Any())
        {
            foreach (var car in cars)
            {
                Console.WriteLine($"Машина: {car.Make} {car.Model} ({car.Year})");
            }
        }
        
        else
        {
            Console.WriteLine("Нет машин в базе данных.");
        }
    }
    
    public static void SoftDeleteCar(ApplicationDbContext context, int carId)
    {
        var car = context.Cars.FirstOrDefault(c => c.Id == carId);
    
        if (car != null)
        {
            car.IsDeleted = true;
            context.SaveChanges();
            Console.WriteLine($"Машина {carId} помечена как удалённая.");
        }
        
        else
        {
            Console.WriteLine("Машина не найдена.");
        }
    }
}