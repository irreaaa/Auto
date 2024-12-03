using System;

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

            Console.WriteLine($"\nОбщий пробег автомобиля: {avto.TotalDistance}км.");
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

            Console.WriteLine($"\nОбщий пробег спорткара: {sportCar.TotalDistance}км.");
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

            Console.WriteLine($"\nОбщий пробег фуры: {truck.TotalDistance}км.");
        }
    }
}

class Auto
{
   string AutoNumber;
   double CurrentV;
   double VMax;
   double Rashod;
   public double TotalDistance;

   public Auto(string autoNumber, double currentV, double vMax, double rashod, double distance)
   {
       AutoNumber = autoNumber;
       CurrentV = currentV;
       VMax = vMax;
       Rashod = rashod / 100;
       TotalDistance = 0;
   }

   public virtual bool Doedet(double km)
   {
       double neededFuel = Rashod * km;
       return CurrentV >= neededFuel;
   }

   public virtual double Proekhat(double km)
   {
       if (!Doedet(km))
       {
           Console.WriteLine("Недостаточно топлива для преодоления указанного расстояния.");
       }

       double fuelUsed = Rashod * km;
       CurrentV -= fuelUsed;
       TotalDistance += km;
       return Math.Round(CurrentV, 2);
   }

    public virtual void Perezaryad(double litres)
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


    public virtual void Itog(double distance)
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

class SportCar : Auto
{
    string AutoNumber;
    double CurrentV;
    double VMax = 105;
    double Rashod = 17;
    new public double TotalDistance;

    public SportCar(string autoNumber, double currentV, double vMax, double rashod, double distance) : base(autoNumber, currentV, vMax, rashod, distance)
    {
        AutoNumber = autoNumber;
        CurrentV = currentV;
        VMax = vMax;
        Rashod = rashod / 100;
        TotalDistance = 0;
    }

    public override void Itog(double distance)
    {
        if (Doedet(distance))
        {
            Console.WriteLine($"Спорткар может проехать это расстояние ({distance}км).");
            Console.WriteLine($"Остаток топлива: {Proekhat(distance)}л.");
        }
        else
        {
            double requiredFuel = distance * Rashod;
            double missingFuel = requiredFuel - CurrentV;
            Console.WriteLine(missingFuel);
            double missingKm = missingFuel / Rashod;
            Console.WriteLine(missingKm);

            Console.WriteLine($"Не хватает топлива для преодоления {missingKm:N2}км.");
            Console.WriteLine("Спорткар не доедет без дозаправки.");
            Console.WriteLine($"Введите количество литров для дозаправки (понадобиться {missingFuel}л.):");
            double dozapravka = Convert.ToDouble(Console.ReadLine());
            Perezaryad(dozapravka);
            Itog(distance);
        }
    }
}

class Truck : Auto
{
    string AutoNumber;
    double CurrentV;
    double VMax = 500;
    double Rashod = 25.5;
    public double TotalDistance;

    public Truck(string autoNumber, double currentV, double vMax, double rashod, double distance) : base(autoNumber, currentV, vMax, rashod, distance)
    {
        AutoNumber = autoNumber;
        CurrentV = currentV;
        VMax = vMax;
        Rashod = rashod / 100;
        TotalDistance = 0;
    }

    public override void Itog(double distance)
    {
        if (Doedet(distance))
        {
            Console.WriteLine($"Фура может проехать это расстояние ({distance}км).");
            Console.WriteLine($"Остаток топлива: {Proekhat(distance)}л.");
        }
        else
        {
            double requiredFuel = distance * Rashod;
            double missingFuel = requiredFuel - CurrentV;
            double missingKm = missingFuel / Rashod;

            Console.WriteLine($"Не хватает топлива для преодоления {missingKm:N2}км.");
            Console.WriteLine("Фура не доедет без дозаправки.");
            Console.WriteLine("Введите количество литров для дозаправки:");
            double dozapravka = Convert.ToDouble(Console.ReadLine());
            Perezaryad(dozapravka);
            Itog(distance);
        }
    }
}

//9,8l 17 l/km