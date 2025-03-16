using Microsoft.EntityFrameworkCore;

namespace CarService.Manipulation;

public static class ServiceManipulation
{
    public static void AddOrderedServices(CarServiceContext context)
    {
        Console.Write("Введите ID заказа: ");
        var orderId = int.Parse(Console.ReadLine()!);
        var order = context.Orders.Include(o => o.OrderedServices).FirstOrDefault(o => o.Id == orderId);

        if (order == null)
        {
            Console.WriteLine("Заказ не найден.");
            return;
        }

        Console.WriteLine("Выберите услуги:");
        var services = context.Services.ToList();
        for (int i = 0; i < services.Count; i++)
        {
            var serviceItem = services[i];
            Console.WriteLine($"{i + 1}. {serviceItem.ServiceName} - {serviceItem.ServicePrice} руб.");
        }

        var serviceIndex = int.Parse(Console.ReadLine()!) - 1;
        var service = services[serviceIndex];

        Console.Write("Введите количество: ");
        var quantity = int.Parse(Console.ReadLine()!);

        var orderedService = new OrderedServices()
        {
            OrderId = orderId,
            ServiceId = service.ServiceId,
            Count = quantity,
            TotalAmount = service.ServicePrice * quantity
        };

        order.OrderedServices.Add(orderedService);
        context.SaveChanges();
    }
    
    public static void GetTotalCostByCustomerLogin(CarServiceContext context, Customer currentCustomer)
    {
        if (currentCustomer == null)
        {
            Console.WriteLine("Пользователь не авторизован.");
            return;
        }

        var orders = context.Orders
            .Include(o => o.OrderedServices)
            .ThenInclude(os => os.Service)
            .Where(o => o.CustomerId == currentCustomer.Id)
            .ToList();

        foreach (var order in orders)
        {
            Console.WriteLine($"Заказ ID: {order.Id}");
            foreach (var orderedService in order.OrderedServices)
            {
                Console.WriteLine($" - Услуга: {orderedService.Service.ServiceName}, Количество: {orderedService.Count}, Цена: {orderedService.Service.ServicePrice}");
            }
        }

        if (!orders.Any())
        {
            Console.WriteLine("У клиента нет заказов.");
            return;
        }

        decimal totalCost = orders.Sum(order => order.OrderedServices.Sum(os => os.Service.ServicePrice * os.Count));

        Console.WriteLine($"Общая стоимость заказов клиента с логином {currentCustomer.Login}: {totalCost} руб.");
    }
}