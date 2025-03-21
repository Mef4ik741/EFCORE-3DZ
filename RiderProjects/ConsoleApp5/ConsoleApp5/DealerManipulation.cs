namespace ConsoleApp5;

public static class DealerManipulation
{
    public static void AddDealer(ApplicationDbContext context, Dealer dealer)
    {
        context.Dealers.Add(dealer);
        context.SaveChanges();
        Console.WriteLine($"Диллер {dealer.Name} был добавлен в базу данных");
    }

    public static void DeleteDealer(ApplicationDbContext context, int dealerId)
    {
        var dealer = context.Dealers.FirstOrDefault(c => c.Id == dealerId);
        
        context.Dealers.Remove(dealer!);
        context.SaveChanges();
        Console.WriteLine($"Диллер {dealer!.Name} был удален из базы данных");
    }

    public static void UpdateDealer(ApplicationDbContext context, int dealerId, string newName, string newLocation)
    {
        var dealer = context.Dealers.FirstOrDefault(c => c.Id == dealerId);
        if (dealer != null )
        {
            dealer!.Name = newName;
            dealer!.Location = newLocation;
            context.SaveChanges();
        }

        else
        {
            Console.WriteLine("Диллер не найден.");
        }
    }

    public static void GetAllDealers(ApplicationDbContext context)
    {
        var dealers = context.Dealers.ToList();
        
        if (dealers.Any())
        {
            foreach (var dealer in dealers)
            {
                Console.WriteLine($"ID: {dealer.Id}, Имя: {dealer.Name}, Локация: {dealer.Location}");
            }
        }

        else
        {
            Console.WriteLine("нет диллеров");
        }
    }
}