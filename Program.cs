using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var train = new PassengerTrain();

        Console.WriteLine("Введите количество вагонов для добавления:");
        if (!int.TryParse(Console.ReadLine(), out int wagonCount) || wagonCount <= 0)
        {
            Console.WriteLine("Некорректное количество вагонов.");
            return;
        }

        for (int i = 0; i <= wagonCount; i++)
        {
            Console.WriteLine($"\nВвод данных для вагона #{i + 1}:");
            Console.WriteLine("Выберите тип вагона: 1 - Купе, 2 - Плацкарт, 3 - СВ");
            string wagonType = Console.ReadLine();

            switch (wagonType)
            {
                case "1":
                    var coupeWagon = CreateCoupeWagonFromInput();
                    if (coupeWagon != null)
                        train.AddWagon(coupeWagon);
                    break;
                case "2":
                    var platskartWagon = CreatePlatskartWagonFromInput();
                    if (platskartWagon != null)
                        train.AddWagon(platskartWagon);
                    break;
                case "3":
                    var svWagon = CreateSVWagonFromInput();
                    if (svWagon != null)
                        train.AddWagon(svWagon);
                    break;
                default:
                    Console.WriteLine("Неверный тип вагона. Пропускаем этот вагон.");
                    break;
            }
        }

        decimal totalIncome = train.GetTotalIncome();
        Console.WriteLine($"\nОбщий доход от рейса: {totalIncome} руб.");
    }

    static CoupeWagon CreateCoupeWagonFromInput()
    {
        try
        {
            Console.WriteLine("Введите количество нижних мест:");
            int lower = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество верхних мест:");
            int upper = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество боковых нижних мест:");
            int lowerSide = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество боковых верхних мест:");
            int upperSide = int.Parse(Console.ReadLine());

            var services = ReadServices();

            return new CoupeWagon(lower, upper, lowerSide, upperSide, services);
        }
        catch
        {
            Console.WriteLine("Ошибка при вводе данных для купе вагона.");
            return null;
        }
    }

    static PlatskartWagon CreatePlatskartWagonFromInput()
    {
        try
        {
            Console.WriteLine("Введите количество нижних мест:");
            int lower = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество верхних мест:");
            int upper = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество боковых нижних мест:");
            int lowerSide = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество боковых верхних мест:");
            int upperSide = int.Parse(Console.ReadLine());

            var services = ReadServices();

            return new PlatskartWagon(lower, upper, lowerSide, upperSide, services);
        }
        catch
        {
            Console.WriteLine("Ошибка при вводе данных для плацкарт вагона.");
            return null;
        }
    }

    static SVWagon CreateSVWagonFromInput()
    {
        try
        {
            Console.WriteLine("Введите количество нижних мест:");
            int lower = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество верхних мест:");
            int upper = int.Parse(Console.ReadLine());

            var services = ReadServices();

            return new SVWagon(lower, upper, services);
        }
        catch
        {
            Console.WriteLine("Ошибка при вводе данных для СВ вагона.");
            return null;
        }
    }

    static Dictionary<string, decimal> ReadServices()
    {
        var services = new Dictionary<string, decimal>();

        Console.WriteLine("Введите количество дополнительных услуг:");
        if (!int.TryParse(Console.ReadLine(), out int serviceCount) || serviceCount < 0)
        {
            Console.WriteLine("Некорректное количество услуг, считаем 0.");
            return services;
        }

        for (int i = 0; i < serviceCount; i++)
        {
            Console.WriteLine($"Введите название услуги #{i + 1}:");
            string name = Console.ReadLine();

            Console.WriteLine($"Введите стоимость услуги \"{name}\":");
            if (decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                services[name] = price;
            }
            else
            {
                Console.WriteLine("Некорректная стоимость, услуга пропущена.");
            }
        }

        return services;
    }
}
