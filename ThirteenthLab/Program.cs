using System;
using System.IO;

namespace ThirteenthLab
{
    public class Car
    {
        public string? Brand { get; set; }
        public string? LicensePlate { get; set; }
        public string? OwnerName { get; set; }
    }

    public class Camera
    {
        public delegate void CarSpeedHandler(string message, int speed);
        public event CarSpeedHandler? SpeedingDetected;

        public void CheckSpeed(Car car, int currentSpeed, int allowedSpeed)
        {
            if (currentSpeed > allowedSpeed && SpeedingDetected != null)
            {
                SpeedingDetected(
                    $"Гос.знак: {car.LicensePlate}, Марка: {car.Brand}, ФИО владельца: {car.OwnerName}",
                    currentSpeed
                );
            }
        }
    }

    public class TrafficPolice
    {
        public static void OnSpeedingDetected(string carInfo, int speed)
        {
            string penalty =
                $"Штраф за превышение скорости.\nИнформация об автомобиле: {carInfo}.\nСкорость: {speed} км/ч.";
            File.AppendAllText("speeding_tickets.txt", penalty);
            Console.WriteLine(penalty);
        }
    }

    class Program
    {
        delegate double EquationDelegate(double x);

        static double SolveEquation(EquationDelegate f, double a, double b, double accuracy)
        {
            if (f(a) * f(b) > 0)
            {
                throw new ArgumentException(
                    "Функция должна иметь противоположные знаки на концах отрезка"
                );
            }

            double c;
            while (true)
            {
                c = (a + b) / 2;
                if (Math.Abs(f(c)) < accuracy)
                {
                    return c;
                }

                if (f(c) * f(a) > 0)
                {
                    a = c;
                }
                else
                {
                    b = c;
                }
            }
        }

        static void Main()
        {
            static void firstTask()
            {
                EquationDelegate f = x => Math.Pow(x, 3) - 9;
                double result = SolveEquation(f, 0, 5, 0.0001);
                Console.WriteLine("Решение уравнения: " + result);
                Console.WriteLine();
            }

            firstTask();

            static void secondTask()
            {
                Car car =
                    new()
                    {
                        Brand = "Тойота",
                        LicensePlate = "АБ123В",
                        OwnerName = "Иванов Иван Иванович"
                    };
                Camera camera = new();
                TrafficPolice trafficPolice = new();

                camera.SpeedingDetected += TrafficPolice.OnSpeedingDetected;

                camera.CheckSpeed(car, 120, 80);
            }

            secondTask();
        }
    }
}
