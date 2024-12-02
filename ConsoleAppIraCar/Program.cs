using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите цирфу, для какого авто вы хотите сделать расчет: обычная(1), спорткар(2), фура(3)");
        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
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

            Console.WriteLine($"\nОбщий пробег автомобиля: {avto.TotalDistance}км.");
        }
        if (choice == 2)
        {
            double vMax = 105;
            double rashod = 17;
            string autoNumber = "1SPR23";

            Console.WriteLine("Введите текущий объем бака: ");
            double CurrentVS = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите расстояние, которое вы хотите проехать: ");
            double distanceS = Convert.ToDouble(Console.ReadLine());
            
            SportCar sportCar = new SportCar(autoNumber, CurrentVS, vMax, rashod, distanceS);

            sportCar.Itog(distanceS);

            while (true)
            {
                Console.WriteLine("\nВведите расстояние, которое вы хотите проехать (или нажмите 'в' для выхода): ");
                string inputDistance = Console.ReadLine();

                if (inputDistance == "в" || inputDistance == "d")
                {
                    break;
                }

                distanceS = Convert.ToDouble(inputDistance);
                sportCar.Itog(distanceS);
            }

            Console.WriteLine($"\nОбщий пробег автомобиля: {sportCar.TotalDistance}км.");
        }
        if (choice == 3)
        {
            double vMax = 500;
            double rashod = 25.5;
            string autoNumber = "1TRC23";

            Console.WriteLine("Введите текущий объем бака: ");
            double CurrentVT = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите расстояние, которое вы хотите проехать: ");
            double distanceT = Convert.ToDouble(Console.ReadLine());
            
            Truck truck = new Truck(autoNumber, CurrentVT, vMax, rashod, distanceT);

            truck.Itog(distanceT);

            while (true)
            {
                Console.WriteLine("\nВведите расстояние, которое вы хотите проехать (или нажмите 'в' для выхода): ");
                string inputDistance = Console.ReadLine();

                if (inputDistance == "в" || inputDistance == "d")
                {
                    break;
                }

                distanceT = Convert.ToDouble(inputDistance);
                truck.Itog(distanceT);
            }

            Console.WriteLine($"\nОбщий пробег автомобиля: {truck.TotalDistance}км.");
        }
    }
}
class  Auto
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

   public bool Doedet(double km)
   {
       double neededFuel = Rashod * km;
       return CurrentV >= neededFuel;
   }

   public double Proekhat(double km)
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

   public void Perezaryad(double litres)
   {
       if (litres <= 0)
       {
           Console.WriteLine("Объем топлива не может быть отрицательным.");
           return;
       }

       if (CurrentV + litres > VMax)
       {
           Console.WriteLine("Количество топлива не может превышать объем бака.");
           return;
       }
       CurrentV += litres;
       Console.WriteLine($"Вы успешно заправили {litres}л. Текущий объем топлива: {CurrentV}л.");
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

class SportCar : Auto
{
    public SportCar(string autoNumber, double currentV, double vMax, double rashod, double distance) : base(autoNumber, currentV, vMax, rashod, distance) { }
}

class Truck : Auto
{
    public Truck(string autoNumber, double currentV, double vMax, double rashod, double distance) : base(autoNumber, currentV, vMax, rashod, distance) { }
}