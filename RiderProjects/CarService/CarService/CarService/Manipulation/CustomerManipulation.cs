using System.Threading.Channels;

namespace CarService.Manipulation;

public static class CustomerManipulation
{
    public static void DeleteCustomer(CarServiceContext context)
    {
        Console.WriteLine("Введите ID клиента: ");
        int customerId = int.Parse(Console.ReadLine()!);
        
        var customer = context.Customers.Find(customerId);

        if (customer != null)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
        }

        else
        {
            Console.WriteLine("Не найдено");
        }

        Console.WriteLine("Клиент удален!");
    }

    public static void UpdateCustomer(CarServiceContext context)
    {
        Console.WriteLine("Введите ID клиента: ");
        int customerId = int.Parse(Console.ReadLine()!);
        
        var customer = context.Customers.Find(customerId);
        
        if (customer == null)
        {
            Console.WriteLine("Клиент не найден.");
            return;
        }
        
        while (true)
        {
            Console.WriteLine("1 - Изменить имя");
            Console.WriteLine("2 - Изменить Фамилию");
            Console.WriteLine("3 - Изменить Номер");
            Console.WriteLine("4 - Изменить Логин");
            Console.WriteLine("5 - Изменить Пароль");
            Console.WriteLine("6 - Выйти из программы");
            int choice = int.Parse(Console.ReadLine()!);

            if (choice == 1)
            {
                Console.Write("Введите имя: ");
                string name = Console.ReadLine()!;
                
                customer.Name = name;
            }
            
            else if (choice == 2)
            {
                Console.Write("Введите фамилию: ");
                string surname = Console.ReadLine()!;
                
                customer.Surname = surname;
            }
            
            else if (choice == 3)
            {
                Console.Write("Введите номер: ");
                string phone = Console.ReadLine()!;
                
                customer.Phone = phone;
            }
            
            else if (choice == 4)
            {
                Console.Write("Введите логин: ");
                string login = Console.ReadLine()!;
                
                customer.Login = login;
            }
            
            else if (choice == 5)
            {
                Console.Write("Введите пароль: ");
                string password = Console.ReadLine()!;
                
                customer.Password = password;
            }
            
            else if (choice == 6)
            {
                break;
            }
        }
        
        context.SaveChanges();
    }

    public static void GetAllCustomers(CarServiceContext context)
    {
        var customers = context.Customers.ToList();

        if (customers.Any())
        {
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.Id}\n Имя: {customer.Name} Фамилия: {customer.Surname} Мобильный номер: {customer.Phone} Логин: {customer.Login} Пароль: {customer.Password}");
            }
        }

        else
        {
            Console.WriteLine("Пусто!");
        }
    }
}