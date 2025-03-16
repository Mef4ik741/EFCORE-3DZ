using Microsoft.EntityFrameworkCore;

namespace CarService.Manipulation;

public static class OrderManipulation
{
    public static void AddOrder(CarServiceContext context)
    {
        Console.Write("Введите клиентский ID: ");
        var customerId = int.Parse(Console.ReadLine()!);
        var customer = context.Customers
            .Where(c => c.Id == customerId)
            .Include(c => c.Cars) 
            .ToList()
            .FirstOrDefault();


        if (customer == null)
        {
            Console.WriteLine("Клиент не найден.");
            return;
        }

        var carsList = customer.Cars.ToList();

        Console.WriteLine("Выберите автомобиль из списка:");
        for (int i = 0; i < carsList.Count; i++)
        {
            var car = carsList[i];  
            Console.WriteLine($"{i + 1}. {car.Brand} {car.Model} ({car.Year})");
        }

        
        var carIndex = int.Parse(Console.ReadLine()!) - 1;
        var carId = customer.Cars.ElementAt(carIndex).Id;

        Console.Write("Введите дату заказа (yyyy-MM-dd): ");
        var orderDate = DateTime.Parse(Console.ReadLine()!);


        var order = new Order
        {
            CustomerId = customerId,
            CarId = carId,
            OrderDate = orderDate,
            Status = true
        };
        context.Orders.Add(order);
        context.SaveChanges();
    }

    public static void ShowOrderHistory(CarServiceContext context)
    {
        Console.Write("Введите клиентский ID: ");
        int customerid = int.Parse(Console.ReadLine()!);

        var customer = context.Customers
            .Include(c => c.Orders)
            .ThenInclude(o => o.OrderedServices)
            .ThenInclude(os => os.Service)
            .FirstOrDefault(c => c.Id == customerid);

        if (customer == null)
        {
            Console.WriteLine("Клиент не найден.");
            return;
        }

        if (customer.Orders == null || !customer.Orders.Any())
        {
            Console.WriteLine($"У клиента {customer.Name} {customer.Surname} нет заказов.");
            return;
        }

        Console.WriteLine($"История заказов клиента {customer.Name} {customer.Surname}:");
        foreach (var order in customer.Orders)
        {
            Console.WriteLine($"Дата: {order.OrderDate.ToShortDateString()}, Статус: {(order.Status ? "Завершен" : "В процессе")}");

            if (order.OrderedServices == null || !order.OrderedServices.Any())
            {
                Console.WriteLine("Услуги отсутствуют.");
                continue;
            }

            foreach (var orderedService in order.OrderedServices)
            {
                if (orderedService.Service != null)
                {
                    Console.WriteLine($"Услуга: {orderedService.Service.ServiceName}, Количество: {orderedService.Count}, Сумма: {orderedService.TotalAmount} руб.");
                }
                else
                {
                    Console.WriteLine("Услуга: Неизвестна, данные отсутствуют.");
                }
            }
        }
    }
}