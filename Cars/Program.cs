using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите цирфу, для какого авто Вы хотите сделать расчет: обычная(1), спорткар(2), фура(3)");
        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
        {
            Console.WriteLine("Введите максимальный объем бака: ");
            double VMax = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите текущий объем бака: ");
            double CurrentV = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите расход топлива на Вашем автомобиле: ");
            double Rashod = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите расстояние, которое Вы хотите проехать: ");
            double distance = Convert.ToDouble(Console.ReadLine());

            Auto avto = new Auto("A123BC", CurrentV, VMax, Rashod, distance);

            avto.Itog(distance);

            while (true)
            {
                Console.WriteLine("\nВведите расстояние, которое Вы хотите проехать (или нажмите 'в' для выхода): ");
                string inputDistance = Console.ReadLine();

                if (inputDistance == "в" || inputDistance == "d")
                {
                    break;
                }

                distance = Convert.ToDouble(inputDistance);
                avto.Itog(distance);
            }
            Console.WriteLine($"Общий пробег автомобиля: {avto.getTotalDistance()}км.");
        }
        if (choice == 2)
        {
            double VMax = 105;
            double Rashod = 17;
            string AutoNumber = "1SPR23";

            Console.WriteLine("Введите текущий объем бака: ");
            double CurrentV = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите расстояние, которое Вы хотите проехать: ");
            double distance = Convert.ToDouble(Console.ReadLine());

            SportCar sportCar = new SportCar(AutoNumber, CurrentV, VMax, Rashod, distance);

            sportCar.Itog(distance);

            while (true)
            {
                Console.WriteLine("\nВведите расстояние, которое Вы хотите проехать (или нажмите 'в' для выхода): ");
                string inputDistance = Console.ReadLine();

                if (inputDistance == "в" || inputDistance == "d")
                {
                    break;
                }

                distance = Convert.ToDouble(inputDistance);
                sportCar.Itog(distance);
            }
            Console.WriteLine($"Общий пробег автомобиля: {sportCar.getTotalDistance()}км.");
        }
        if (choice == 3)
        {
            double VMax = 500;
            double Rashod = 25.5;
            string AutoNumber = "1TRC23";

            Console.WriteLine("Введите текущий объем бака: ");
            double CurrentV = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите расстояние, которое Вы хотите проехать: ");
            double distance = Convert.ToDouble(Console.ReadLine());
            Truck truck = new Truck(AutoNumber, CurrentV, VMax, Rashod, distance);
            truck.Itog(distance);

            while (true)
            {
                Console.WriteLine("\nВведите расстояние, которое Вы хотите проехать (или нажмите 'в' для выхода): ");
                string inputDistance = Console.ReadLine();

                if (inputDistance == "в" || inputDistance == "d")
                {
                    break;
                }

                distance = Convert.ToDouble(inputDistance);
                truck.Itog(distance);
            }
            Console.WriteLine($"Общий пробег автомобиля: {truck.getTotalDistance()}км.");
        }
    }
}

class Auto
{
    string AutoN;
    string AutoNumber;
    double VMax;
    double CurrentV;
    double Rashod;
    double Distance;
    double TotalDistance;

    protected internal Auto(string autoNumber, double vMax, double currentV, double rashod, double distance)
    {
        AutoN = "Автомобиль";
        AutoNumber = autoNumber;
        VMax = vMax;
        CurrentV = currentV;
        Rashod = rashod / 100;
        Distance = distance;
        TotalDistance = 0;
    }

    protected internal virtual bool Doedet(double km)
    {
        double neededFuel = Rashod * km;
        return CurrentV >= neededFuel;
    }

    protected internal virtual double Proekhat(double km)
    {
        double fuelUsed = Rashod * km;
        CurrentV -= fuelUsed;
        return Math.Round(CurrentV, 2);
    }

    protected internal virtual void Perezaryad(double litres)
    {
        if (litres <= 0)
        {
            Console.WriteLine("Объем топлива не может быть отрицательным.");
            return;
        }
        if (litres > VMax - CurrentV)
        {
            Console.WriteLine("Количество топлива не может превышать объем бака.");
            return;
        }
        CurrentV += litres;
        Console.WriteLine($"Вы успешно заправили {litres}л. Текущий объем бака: {CurrentV}л.");
    }

    protected internal virtual void Itog(double distance)
    {
        if (Doedet(distance))
        {
            TotalDistance += distance;
            Console.WriteLine($"{AutoN} может проехать это расстояние ({distance:N2}км).");
            Console.WriteLine($"Остаток топлива: {Proekhat(distance)}л.");
        }
        else
        {
            double requiredFuel = distance * Rashod;
            double missingFuel = requiredFuel - CurrentV;
            double missingKm = missingFuel / Rashod;

            TotalDistance += distance - missingKm;

            CurrentV = 0;
            Console.WriteLine($"Нехватает топлива для преодоления {missingKm:N2}км.");
            Console.WriteLine("Автомобиль не доедет без дозаправки.");
            Console.WriteLine("Введите количество топлива для дозаправки: ");
            double dozapravka = Convert.ToDouble(Console.ReadLine());
            Perezaryad(dozapravka);
            Itog(missingKm);
        }
    }
    protected internal double getTotalDistance()
    {
        return TotalDistance;
    }
}

class SportCar : Auto
{
    public SportCar(string autoNumber, double currentV, double vMax, double rashod, double distance) : base(autoNumber, currentV, vMax, rashod, distance)
    {
    }
    protected internal void Itog(double distance)
    {
        base.Itog(distance);
    }
}

class Truck : Auto
{
    public Truck(string autoNumber, double currentV, double vMax, double rashod, double distance) : base(autoNumber, currentV, vMax, rashod, distance)
    {
    }
    protected internal void Itog(double distance)
    {
        base.Itog(distance);
    }
}

