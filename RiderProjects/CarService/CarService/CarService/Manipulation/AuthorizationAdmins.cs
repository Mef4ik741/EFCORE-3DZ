namespace CarService.Manipulation;

public class AuthorizationAdmins
{
    private CarServiceContext context;

    public AuthorizationAdmins(CarServiceContext context)
    {
        this.context = context;
    }
    
    public bool RegistrationAdmins(string name, string surname, string login, string password)
    {
        if (context.Admins.Any(c => c.Login == login))
        {
            Console.WriteLine($"Админ с таким {login} уже существует!");
            return false;
        }

        var admin = new Admin
        {
            AdminName = name,
            AdminSurname = surname,
            Login = login,
            Password = password,
        };
        
        context.Admins.Add(admin);
        context.SaveChanges();
        
        Console.WriteLine("Регистрация успешна!");
        return true; 
    }
    
    public bool LoginAdmins(string login, string password)
    {
        var admin = context.Admins.FirstOrDefault(a => a.Login == login);
    
        if (admin == null || admin.Password != password)
        {
            Console.WriteLine("Неверный логин или пароль!");
            return false;
        }

        Console.WriteLine("Вход выполнен успешно!");
        return true;
    }
}