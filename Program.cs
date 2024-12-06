using System;

abstract class Shape
{
    protected float x0, y0, radius;

    public Shape(float x0, float y0, float radius)
    {
        this.x0 = x0;
        this.y0 = y0;
        this.radius = radius;
    }

    // Абстрактні методи для реалізації в похідних класах
    public abstract void DisplayInfo();
    public abstract float CalculateMeasure();
}

class Circle : Shape
{
    public Circle(float x0, float y0, float radius) : base(x0, y0, radius) { }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Circle center: ({x0}, {y0}), Radius: {radius}");
    }

    public override float CalculateMeasure()
    {
        return 2 * (float)Math.PI * radius; // Довжина кола
    }
}

class Sphere : Shape
{
    private float z0;

    public Sphere(float x0, float y0, float z0, float radius) : base(x0, y0, radius)
    {
        this.z0 = z0;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Sphere center: ({x0}, {y0}, {z0}), Radius: {radius}");
    }

    public override float CalculateMeasure()
    {
        return 4 * (float)Math.PI * radius * radius; // Площа поверхні сфери
    }

    // Додатковий метод для обчислення об'єму сфери
    public float CalculateVolume()
    {
        return (4f / 3f) * (float)Math.PI * (float)Math.Pow(radius, 3); // Об'єм сфери
    }
}

class Program
{
    static void Main()
    {
        // Запит користувача на вибір фігури
        Console.WriteLine("Enter the shape type (Circle/Sphere):");
        string shapeType = Console.ReadLine();

        Shape shape = null;

        if (shapeType.ToLower() == "circle")
        {
            shape = CreateCircle();
        }
        else if (shapeType.ToLower() == "sphere")
        {
            shape = CreateSphere();
        }
        else
        {
            Console.WriteLine("Invalid shape type!");
            return;
        }

        // Використання поліморфізму
        shape.DisplayInfo();
        Console.WriteLine($"Calculated measure: {shape.CalculateMeasure()}");

        if (shape is Sphere sphere)
        {
            Console.WriteLine($"Volume: {sphere.CalculateVolume()}");
        }

        Console.ReadKey();
    }

    // Функція для створення об'єкта Circle
    static Circle CreateCircle()
    {
        Console.WriteLine("Enter the center coordinates (x, y) and radius for the circle:");

        float x0 = GetFloatInput("Enter x0: ");
        float y0 = GetFloatInput("Enter y0: ");
        float radius = GetFloatInput("Enter radius: ");

        return new Circle(x0, y0, radius);
    }

    // Функція для створення об'єкта Sphere
    static Sphere CreateSphere()
    {
        Console.WriteLine("Enter the center coordinates (x, y, z) and radius for the sphere:");

        float x0 = GetFloatInput("Enter x0: ");
        float y0 = GetFloatInput("Enter y0: ");
        float z0 = GetFloatInput("Enter z0: ");
        float radius = GetFloatInput("Enter radius: ");

        return new Sphere(x0, y0, z0, radius);
    }

    // Функція для отримання правильного числового вводу
    static float GetFloatInput(string prompt)
    {
        float value;
        while (true)
        {
            Console.Write(prompt);
            if (float.TryParse(Console.ReadLine(), out value) && value > 0)
            {
                break;
            }
            Console.WriteLine("Invalid input. Please enter a positive number.");
        }
        return value;
    }
}
