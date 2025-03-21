using System.Net.Http.Headers;

namespace ConsoleApp5;

public static class CustomerManipulation
{
    public static void AddCustomers(ApplicationDbContext context, Customer customer)
    {
        context.Customers.Add(customer);
        context.SaveChanges();
        Console.WriteLine($"Клиент {customer.Name} был добавлен в базу данных");
    }

    public static void DeleteCustomer(ApplicationDbContext context, int customerId)
    {
        var customer = context.Customers.FirstOrDefault(c => c.Id == customerId);
        context.Customers.Remove(customer!);
        context.SaveChanges();
        Console.WriteLine($"Клиент {customer!.Name} был удален из базы данных");
    }

    public static void UpdateCustomer(ApplicationDbContext context, int customerId, string newName)
    {
        var customer = context.Customers.FirstOrDefault(c => c.Id == customerId);

        if (customer != null)
        {
            customer.Name = newName;
            context.SaveChanges();
            Console.WriteLine($"Клиент {customerId} обновлена.");
        }

        else
        {
            Console.WriteLine("Клиент не найден.");
        }
    }

    public static void GetallCustomers(ApplicationDbContext context)
    {
        var customers = context.Customers.ToList();

        if (customers.Any())
        {
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.Id}, Имя: {customer.Name}");
            }
        }

        else
        {
            Console.WriteLine("нет клиентов");
        }
    }
}