using System.Reflection;

class Program
{
    static void Main()
    {

        Console.WriteLine("Введите максимальный объем бака: ");
        double VMax = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите текущий объем бака: ");
        double CurrentV = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите расход топлива на вашем автомобиле: ");
        double Rashod = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите расстояние, которое вы хотите проехать: ");
        double distance = Convert.ToDouble(Console.ReadLine());

        Auto avto = new Auto("A123BC", CurrentV, VMax, Rashod, distance);

        avto.Itog(distance);

        while (true)
        {
            Console.WriteLine("\nВведите расстояние, которое вы хотите проехать (или нажмите 'в' для выхода): ");
            string inputDistance = Console.ReadLine();

            if (inputDistance == "в" || inputDistance == "d")
            {
                break;
            }

            distance = Convert.ToDouble(inputDistance);
            avto.Itog(distance);
        }
    }
}

class Auto
{
    string AutoNumber;
    double CurrentV;
    double VMax;
    double Rashod;

    public Auto(string autoNumber, double currentV, double vMax, double rashod, double distance)
    {
        AutoNumber = autoNumber;
        CurrentV = currentV;
        VMax = vMax;
        Rashod = rashod / 100;
    }

    public bool Doedet(double km)
    {
        double skNado = Rashod * km;
        return CurrentV >= skNado;
    }

    public double Proekhat(double km)
    {
        if (!Doedet(km))
        {
            Console.WriteLine("Недостаточно топлива для преодоления указанного расстояния.");
        }

        double skPotratit = Rashod * km;
        CurrentV -= skPotratit;
        return Math.Round(CurrentV, 2);
    }

    public void Perezaryad(double litres)
    {
        if (litres <= 0)
        {
            Console.WriteLine("Объем топлива не может быть отрицательным.");
            return;
        }

        if (litres > VMax)
        {
            Console.WriteLine("Количество топлива не может превышать объем бака.");
            return;
        }
        CurrentV += litres;
        Console.WriteLine($"Вы успешно заправили {litres}л. Текущий объем топлива: {litres}л.");
    }

    public void Itog(double distance)
    {
        if (Doedet(distance))
        {
            Console.WriteLine($"Автомобиль может проехать это расстояние ({distance}км).");
            Console.WriteLine($"Остаток топлива: {Proekhat(distance)}л.");
        }
        else
        {
            double requiredFuel = distance * Rashod;
            double missingFuel = requiredFuel - CurrentV;
            double missingKm = missingFuel / Rashod;

            Console.WriteLine($"Не хватает топлива для преодоления {missingKm:N2}км.");
            Console.WriteLine("Автомобиль не доедет без дозаправки.");
            Console.WriteLine("Введите количество литров для дозаправки:");
            double dozapravka = Convert.ToDouble(Console.ReadLine());
            Perezaryad(dozapravka);
            Itog(distance);
        }
    }
}

//при завершении написать пробег авто