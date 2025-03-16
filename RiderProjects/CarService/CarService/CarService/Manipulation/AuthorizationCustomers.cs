namespace CarService.Manipulation;

public class AuthorizationCustomers
{
    private CarServiceContext context;

    public AuthorizationCustomers(CarServiceContext context)
    {
        this.context = context;
    }
    
    public void RegistrationCustomer(string name, string surname , string login, string password, string phone)
    { 
        if (context.Customers.Any(c => c.Login == login))
        {
            Console.WriteLine($"Пользователь с таким {login} уже существует!");
            return;
        }
        
        var customer = new Customer
        {
            Name = name,
            Surname = surname,
            Phone = phone,
            Login = login,
            Password = password,
        };
        
        context.Customers.Add(customer);
        context.SaveChanges();
        
        Console.WriteLine("Регистрация успешна!");
    }

    public bool LoginCustomers(string login, string password)
    {
        var customer = context.Customers.FirstOrDefault(a => a.Login == login);
        
        if (customer == null || customer.Password != password)
        {
            Console.WriteLine("Неверный логин или пароль!");
            return false;
        }
        
        Console.WriteLine("Вход выполнен успешно!");
        return true;
    }
}