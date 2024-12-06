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
}

class Program
{
    static void Main()
    {
        Shape[] shapes = new Shape[2]; // Масив покажчиків на абстрактний клас

        // Динамічне створення об'єктів
        shapes[0] = new Circle(0, 0, 5);
        shapes[1] = new Sphere(0, 0, 0, 5);

        foreach (var shape in shapes)
        {
            // Використання поліморфізму
            shape.DisplayInfo();
            Console.WriteLine($"Calculated measure: {shape.CalculateMeasure()}");
            Console.WriteLine();
        }

        Console.ReadKey();
    }
}
