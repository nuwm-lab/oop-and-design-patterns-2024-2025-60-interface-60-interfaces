using System;

namespace LabWork
{
    // Даний проект є шаблоном для виконання лабораторних робіт
    // з курсу "Об'єктно-орієнтоване програмування та патерни проектування"
    // Необхідно змінювати і дописувати код лише в цьому проекті
    // Відео-інструкції щодо роботи з github можна переглянути 
    // за посиланням https://www.youtube.com/@ViktorZhukovskyy/videos 

    using System;

    // Інтерфейс IShape
    public interface IShape
    {
        void SetCoordinates(params double[] coordinates); // Метод для задання координат
        string PrintCoordinates();                       // Метод для виведення координат
        double CalculateArea();                          // Метод для обчислення площі
    }

    // Абстрактний клас Shape
    public abstract class Shape : IShape
    {
        public abstract void SetCoordinates(params double[] coordinates);
        public abstract string PrintCoordinates();
        public abstract double CalculateArea();

        public Shape()
        {
            Console.WriteLine("Об'єкт фігури створено.");
        }

        ~Shape()
        {
            Console.WriteLine("Об'єкт фігури знищено.");
        }
    }

    // Клас Triangle успадковує Shape та реалізує IShape
    public class Triangle : Shape
    {
        protected double x1, y1, x2, y2, x3, y3;

        public override void SetCoordinates(params double[] coordinates)
        {
            if (coordinates.Length != 6)
                throw new ArgumentException("Трикутник потребує 6 координат (x1, y1, x2, y2, x3, y3).");

            x1 = coordinates[0];
            y1 = coordinates[1];
            x2 = coordinates[2];
            y2 = coordinates[3];
            x3 = coordinates[4];
            y3 = coordinates[5];
        }

        public override string PrintCoordinates()
        {
            return $"Трикутник: A({x1}, {y1}), B({x2}, {y2}), C({x3}, {y3})";
        }

        public override double CalculateArea()
        {
            return Math.Abs((x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2.0);
        }
    }

    // Клас ConvexQuadrilateral успадковує Shape
    public class ConvexQuadrilateral : Shape
    {
        private double x1, y1, x2, y2, x3, y3, x4, y4;

        public override void SetCoordinates(params double[] coordinates)
        {
            if (coordinates.Length != 8)
                throw new ArgumentException("Чотирикутник потребує 8 координат (x1, y1, x2, y2, x3, y3, x4, y4).");

            x1 = coordinates[0];
            y1 = coordinates[1];
            x2 = coordinates[2];
            y2 = coordinates[3];
            x3 = coordinates[4];
            y3 = coordinates[5];
            x4 = coordinates[6];
            y4 = coordinates[7];
        }

        public override string PrintCoordinates()
        {
            return $"Опуклий чотирикутник: A({x1}, {y1}), B({x2}, {y2}), C({x3}, {y3}), D({x4}, {y4})";
        }

        public override double CalculateArea()
        {
            double area1 = Math.Abs((x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2.0);
            double area2 = Math.Abs((x1 * (y3 - y4) + x3 * (y4 - y1) + x4 * (y1 - y3)) / 2.0);
            return area1 + area2;
        }
    }

    // Головний клас програми
    class Program
    {
        static void Main(string[] args)
        {
            IShape triangle = new Triangle();
            // Нові координати трикутника
            triangle.SetCoordinates(1, 1, 6, 1, 3, 5);
            Console.WriteLine(triangle.PrintCoordinates());
            Console.WriteLine($"Площа: {triangle.CalculateArea()}");

            IShape quadrilateral = new ConvexQuadrilateral();
            // Нові координати чотирикутника
            quadrilateral.SetCoordinates(2, 2, 7, 2, 6, 6, 3, 7);
            Console.WriteLine(quadrilateral.PrintCoordinates());
            Console.WriteLine($"Площа: {quadrilateral.CalculateArea()}");
        }
    }
}