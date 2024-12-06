using System;

// Інтерфейс для дробів
interface IFraction
{
    void SetCoefficients();
    void DisplayCoefficients();
    double Calculate(double x);
}

// Абстрактний клас для загальних особливостей дробів
abstract class AbstractFraction : IFraction
{
    protected double a1;

    public AbstractFraction(double coefficient1 = 1)
    {
        a1 = coefficient1;
        Console.WriteLine("Абстрактний дріб створено.");
    }

    ~AbstractFraction()
    {
        Console.WriteLine("Абстрактний дріб знищено.");
    }

    // Загальні методи
    public abstract void SetCoefficients();
    public abstract void DisplayCoefficients();
    public abstract double Calculate(double x);
}

// Простий дріб
class Fraction : AbstractFraction
{
    public Fraction(double coefficient1 = 1) : base(coefficient1)
    {
        Console.WriteLine("Простий дріб створено.");
    }
    ~Fraction()
    {
        Console.WriteLine("Простий дріб знищено.");
    }

    public override void SetCoefficients()
    {
        Console.Write("Введіть коефіцієнт a1: ");
        a1 = Convert.ToDouble(Console.ReadLine());
    }

    public override void DisplayCoefficients()
    {
        Console.WriteLine($"Коефіцієнт a1: {a1}");
    }

    public override double Calculate(double x)
    {
        if (a1 == 0)
            throw new DivideByZeroException("Коефіцієнт a1 не може дорівнювати 0.");
        return 1.0 / (a1 * x + 1);
    }
}

// Тригонометричний підхідний дріб
class TrigonometricFraction : AbstractFraction
{
    private double a2;
    private double a3;

    public TrigonometricFraction(double coefficient1 = 1, double coefficient2 = 1, double coefficient3 = 1) : base(coefficient1)
    {
        a2 = coefficient2;
        a3 = coefficient3;
        Console.WriteLine("Тригонометричний дріб створено.");
    }
    ~TrigonometricFraction()
    {
        Console.WriteLine("Тригонометричний дріб знищено.");
    }

    public override void SetCoefficients()
    {
        Console.Write("Введіть коефіцієнт a1: ");
        a1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введіть коефіцієнт a2: ");
        a2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введіть коефіцієнт a3: ");
        a3 = Convert.ToDouble(Console.ReadLine());
    }

    public override void DisplayCoefficients()
    {
        Console.WriteLine($"Коефіцієнти: a1 = {a1}, a2 = {a2}, a3 = {a3}");
    }

    public override double Calculate(double x)
    {
        if (a1 == 0 || a2 == 0 || a3 == 0)
            throw new DivideByZeroException("Коефіцієнти не можуть дорівнювати 0.");
        return 1.0 / (a1 * x + (1.0 / (a2 * x + (1.0 / (a3 * x + 1)))));
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            AbstractFraction fraction = null;

            Console.WriteLine("Оберіть тип дробу:");
            Console.WriteLine("1. Простий дріб");
            Console.WriteLine("2. Тригонометричний підхідний дріб");
            Console.Write("Ваш вибір (1 або 2): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
                fraction = new Fraction();
            else if (choice == 2)
                fraction = new TrigonometricFraction();
            else
            {
                Console.WriteLine("Неправильний вибір!");
                return;
            }

            fraction.SetCoefficients();

            Console.WriteLine("\nВведені коефіцієнти:");
            fraction.DisplayCoefficients();

            Console.Write("\nВведіть значення x: ");
            double x = Convert.ToDouble(Console.ReadLine());

            double result = fraction.Calculate(x);
            Console.WriteLine($"\nРезультат обчислення дробу при x = {x}: {result}");

            // Примусово викликаємо збір сміття для демонстрації виклику деструктора
            Console.WriteLine("\nВикликаємо GC.Collect()...");
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("\nПрограма завершена.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
