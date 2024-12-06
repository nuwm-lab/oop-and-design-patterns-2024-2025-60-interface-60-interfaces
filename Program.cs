using System;
using System.Text;

namespace LabWork
{
    interface IVolumeCalculable
    {
        double CalculateVolume();
        void DisplayData();
    }

    // Абстрактний клас Shape, який реалізує інтерфейс IVolumeCalculable
    abstract class Shape : IVolumeCalculable
    {
        public abstract void InputData();
        public abstract void DisplayData();
        public abstract double CalculateVolume();

        ~Shape()
        {
            Console.WriteLine("Деструктор для класу Shape викликано.");
        }
    }

    class Celipsoid : Shape
    {
        public int a1, a2, a3;
        public int b1, b2, b3;
        public double Volume { get; private set; }

        public override void InputData()
        {
            Console.WriteLine("Введіть півосі еліпсоїда (a1, a2, a3):");
            a1 = Convert.ToInt32(Console.ReadLine());
            a2 = Convert.ToInt32(Console.ReadLine());
            a3 = Convert.ToInt32(Console.ReadLine());
            if (a1 <= 0 || a2 <= 0 || a3 <= 0)
            {
                throw new ArgumentException("Напівосі еліпсоїда повинні бути додатніми!");
            }

            Console.WriteLine("Введіть координати центру (b1, b2, b3):");
            b1 = Convert.ToInt32(Console.ReadLine());
            b2 = Convert.ToInt32(Console.ReadLine());
            b3 = Convert.ToInt32(Console.ReadLine());
        }

        public override void DisplayData()
        {
            Console.WriteLine($"a1 = {a1}, a2 = {a2}, a3 = {a3}");
            Console.WriteLine($"Центр: b1 = {b1}, b2 = {b2}, b3 = {b3}");
        }

        public override double CalculateVolume()
        {
            Volume = 4.0 / 3.0 * Math.PI * a1 * a2 * a3;
            Console.WriteLine($"Об'єм еліпсоїда: {Volume}");
            return Volume;
        }

        ~Celipsoid()
        {
            Console.WriteLine("Деструктор для класу Celipsoid викликано.");
        }
    }

    class Cball : Shape
    {
        public int Radius { get; private set; }
        public int b1, b2, b3;
        public double Volume { get; private set; }

        public override void InputData()
        {
            Console.WriteLine("Введіть радіус кулі:");
            Radius = Convert.ToInt32(Console.ReadLine());
            if (Radius <= 0)
            {
                throw new ArgumentException("Радіус кулі повинен бути додатнім!");
            }

            Console.WriteLine("Введіть координати центру (b1, b2, b3):");
            b1 = Convert.ToInt32(Console.ReadLine());
            b2 = Convert.ToInt32(Console.ReadLine());
            b3 = Convert.ToInt32(Console.ReadLine());
        }

        public override void DisplayData()
        {
            Console.WriteLine($"Радіус кулі: R = {Radius}");
            Console.WriteLine($"Центр: b1 = {b1}, b2 = {b2}, b3 = {b3}");
        }

        public override double CalculateVolume()
        {
            Volume = 4.0 / 3.0 * Math.PI * Math.Pow(Radius, 3);
            Console.WriteLine($"Об'єм кулі: {Volume}");
            return Volume;
        }

        ~Cball()
        {
            Console.WriteLine("Деструктор для класу Cball викликано.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                try
                {
                    Console.WriteLine("Виберіть, що створити: 1 - Еліпсоїд, 2 - Куля, 0 - Вийти");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 0)
                        break;

                    Shape shape;
                    if (choice == 1)
                        shape = new Celipsoid();
                    else if (choice == 2)
                        shape = new Cball();
                    else
                        throw new ArgumentException("Невірний вибір!");

                    shape.InputData();  // Виклик InputData для відповідного класу
                    shape.DisplayData();
                    shape.CalculateVolume();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Помилка: введіть коректні числові значення.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
            }
        }
    }
}