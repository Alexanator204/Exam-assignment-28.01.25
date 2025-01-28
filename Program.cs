//28.01.25

//                           Экзамен

//Вариант №3
using System;
using System.Collections.Generic;
using System.Linq;

public class Athlete
{
    public string FullName { get; set; }
    public string Country { get; set; }
    public string Sport { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Photo { get; set; } 
    public int GoldMedals { get; set; }
}

public class Sport
{
    public string Name { get; set; }
    public List<Athlete> Athletes { get; set; } = new List<Athlete>();
    public Dictionary<string, int> Results { get; set; } = new Dictionary<string, int>(); // Участник и его результат
}

public class Olympics
{
    public int Year { get; set; }
    public bool IsSummer { get; set; }
    public string HostCountry { get; set; }
    public string HostCity { get; set; }
    public List<Sport> Sports { get; set; } = new List<Sport>();

    public void AddSport(Sport sport)
    {
        Sports.Add(sport);
    }

    public void RemoveSport(string name)
    {
        Sports.RemoveAll(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public Sport GetSport(string name)
    {
        return Sports.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}

public class OlympicsManager
{
    private List<Olympics> olympicsList = new List<Olympics>();

    public void AddOlympics(Olympics olympics)
    {
        olympicsList.Add(olympics);
    }

    public void RemoveOlympics(int year)
    {
        olympicsList.RemoveAll(o => o.Year == year);
    }

    public void ListOlympics()
    {
        foreach (var olympics in olympicsList)
        {
            Console.WriteLine($"Год: {olympics.Year}, Летняя: {olympics.IsSummer}, Страна: {olympics.HostCountry}, Город: {olympics.HostCity}");
        }
    }

    public void ShowMedalTable(int year)
    {
        var olympics = olympicsList.FirstOrDefault(o => o.Year == year);
        if (olympics != null)
        {
            Console.WriteLine($"Медальный зачет на Олимпиаде {year}:");
            
        }
        else
        {
            Console.WriteLine("Олимпиада не найдена.");
        }
    }

    
}

class Program
{
    static void Main(string[] args)
    {
        OlympicsManager manager = new OlympicsManager();

       
        Olympics olympics2024 = new Olympics
        {
            Year = 2024,
            IsSummer = true,
            HostCountry = "США",
            HostCity = "Лос-Анджелес"
        };

       
        Sport basketball = new Sport { Name = "Баскетбол" };
        basketball.Athletes.Add(new Athlete { FullName = "Иванов Иван", Country = "Россия", GoldMedals = 1 });
        olympics2024.AddSport(basketball);

        
        manager.AddOlympics(olympics2024);

        // Меню приложения
        while (true)
        {
            Console.WriteLine("\n1. Просмотреть Олимпиады");
            Console.WriteLine("2. Добавить Олимпиаду");
            Console.WriteLine("3. Удалить Олимпиаду");
            Console.WriteLine("4. Отобразить медальный зачет (по году)");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    manager.ListOlympics();
                    break;
                case "2":
                    Console.Write("Введите год: ");
                    int year = int.Parse(Console.ReadLine());
                    Console.Write("Летняя Олимпиада? (true/false): ");
                    bool isSummer = bool.Parse(Console.ReadLine());
                    Console.Write("Введите страну: ");
                    string country = Console.ReadLine();
                    Console.Write("Введите город: ");
                    string city = Console.ReadLine();

                    Olympics olympics = new Olympics
                    {
                        Year = year,
                        IsSummer = isSummer,
                        HostCountry = country,
                        HostCity = city
                    };
                    manager.AddOlympics(olympics);
                    break;
                case "3":
                    Console.Write("Введите год для удаления: ");
                    int removeYear = int.Parse(Console.ReadLine());
                    manager.RemoveOlympics(removeYear);
                    break;
                case "4":
                    Console.Write("Введите год для отображения медального зачета: ");
                    int medalYear = int.Parse(Console.ReadLine());
                    manager.ShowMedalTable(medalYear);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }
        }
    }
}
