using System;
using CarService;
using CarService.Manipulation;
using Microsoft.EntityFrameworkCore;

class Program
{
    private static string connectionString = "Data Source=localhost;Initial Catalog=CarService;Integrated Security=True;TrustServerCertificate=True";
    
    public static Customer CurrentCustomer { get; set; }

    
    static void Main(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CarServiceContext>();
        optionsBuilder.UseSqlServer(connectionString);

        using (var context = new CarServiceContext(optionsBuilder.Options))
        {
            while (true)
            {
                Console.WriteLine("1 - Войти как Админ");
                Console.WriteLine("2 - Войти как клиент");
                Console.WriteLine("3 - Выйти из программы");
                
                if (!int.TryParse(Console.ReadLine(), out int choiceRoles))
                {
                    Console.WriteLine("Некорректный ввод!");
                    continue;
                }
                
                switch (choiceRoles)
                {
                    case 1:
                        AdminMenu(context);
                        break;
                    case 2:
                        CustomerMenu(context);
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Некорректный выбор!");
                        break;
                }
            }
        }
    }

    static void AdminMenu(CarServiceContext context)
    {
        var admin = new AuthorizationAdmins(context);
        
        while (true)
        {
            Console.WriteLine("1 - Регистрация");
            Console.WriteLine("2 - Войти в аккаунт");
            Console.WriteLine("3 - Выйти из Программы");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Некорректный ввод!");
                continue;
            }
        
            switch (choice)
            {
                case 1:
                    Console.Write("Введите имя: ");
                    string name = Console.ReadLine()!;
                    
                    Console.Write("Введите фамилию: ");
                    string surname = Console.ReadLine()!;
                    
                    Console.Write("Введите логин: ");
                    string loginAdm = Console.ReadLine()!;
                    
                    Console.Write("Введите пароль: ");
                    string passwordAdm = Console.ReadLine()!;
                    
                    admin.RegistrationAdmins(name, surname, loginAdm, passwordAdm);
                    break;
                case 2:
                    Console.Write("Введите логин: ");
                    string login = Console.ReadLine()!;
                            
                    Console.Write("Введите пароль: ");
                    string password = Console.ReadLine()!;
                
                    if (admin.LoginAdmins(login, password)) 
                    {
                        AdminActions(context);
                    }
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Некорректный выбор!");
                    break;
            }
        }
    }
    
    static void AdminActions(CarServiceContext context)
    {
        while (true)
        {
            Console.WriteLine("1 - Управление машинами");
            Console.WriteLine("2 - Управление клиентами");
            Console.WriteLine("3 - Создание заказов на обслуживание");
            Console.WriteLine("4 - Вывод истории заказов клиентов");
            Console.WriteLine("5 - Выйти");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Некорректный ввод!");
                continue;
            }

            switch (choice)
            {
                case 1:
                    ManageCars(context);
                    break;
                case 2:
                    ManageCustomers(context);
                    break;
                case 3:
                    OrderManipulation.AddOrder(context);
                    break;
                case 4:
                    OrderManipulation.ShowOrderHistory(context);
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Некорректный выбор!");
                    break;
            }
        }
    }
    
    static void ManageCars(CarServiceContext context)
    {
        while (true)
        {
            Console.WriteLine("1 - Добавить машину");
            Console.WriteLine("2 - Удалить машину");
            Console.WriteLine("3 - Обновить машину");
            Console.WriteLine("4 - Показать машины клиентов");
            Console.WriteLine("5 - Выход");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Некорректный ввод!");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CrudCarCustomers.AddCarsCustomers(context);
                    break;
                case 2:
                    CrudCarCustomers.DeleteCarsCustomers(context);
                    break;
                case 3:
                    CrudCarCustomers.UpdateCarsCustomers(context);
                    break;
                case 4:
                    CrudCarCustomers.GetAllCarsCustomers(context);
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Некорректный выбор!");
                    break;
            }
        }
    }
    
    static void ManageCustomers(CarServiceContext context)
    {
        while (true)
        {
            Console.WriteLine("1 - Удалить клиента");
            Console.WriteLine("2 - Обновить клиента");
            Console.WriteLine("3 - Показать всех клиентов");
            Console.WriteLine("4 - Выйти");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Некорректный ввод!");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CustomerManipulation.DeleteCustomer(context);
                    break;
                case 2:
                    CustomerManipulation.UpdateCustomer(context);
                    break;
                case 3:
                    CustomerManipulation.GetAllCustomers(context);
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Некорректный выбор!");
                    break;
            }
        }
    }

    static void CustomerMenu(CarServiceContext context)
    {
        var customers = new AuthorizationCustomers(context);
        
        while (true)
        {
            Console.WriteLine("1 - Регистрация");
            Console.WriteLine("2 - Войти в аккаунт");
            Console.WriteLine("3 - Выйти из Программы");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Некорректный ввод!");
                continue;
            }
            
            switch (choice)
            {
                case 1:
                    Console.Write("Введите имя: ");
                    string name = Console.ReadLine()!;
                            
                    Console.Write("Введите фамилию: ");
                    string surname = Console.ReadLine()!;
                            
                    Console.Write("Введите логин: ");
                    string loginCus = Console.ReadLine()!; 
                    
                    Console.Write("Введите пароль: ");
                    string passwordCus = Console.ReadLine()!;

                    Console.Write("Введите номер: ");
                    string phone = Console.ReadLine()!;
                    
                    customers.RegistrationCustomer(name, surname, loginCus, passwordCus, phone);
                    break;
                case 2:
                    Console.Write("Введите логин: ");
                    string login = Console.ReadLine()!;
                            
                    Console.Write("Введите пароль: ");
                    string password = Console.ReadLine()!;

                    if (customers.LoginCustomers(login, password))
                    {
                        CurrentCustomer = context.Customers.FirstOrDefault(c => c.Login == login);
                        CustomerActions(context);
                    }
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Некорректный выбор!");
                    break;
            }
        }
    }

    static void CustomerActions(CarServiceContext context)
    {
        while (true)
        {
            Console.WriteLine("1 - Выбор услуг для заказа");
            Console.WriteLine("2 - Подсчет общей стоимости заказа");
            Console.WriteLine("3 - Выйти");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Некорректный ввод!");
                continue;
            }

            switch (choice)
            {
                case 1:
                    ServiceManipulation.AddOrderedServices(context);
                    break;
                case 2:
                    ServiceManipulation.GetTotalCostByCustomerLogin(context, CurrentCustomer);
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Некорректный выбор!");
                    break;
            }
        }
    }
}
