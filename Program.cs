using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Оберіть проект: 1 - Створити трикутник, 2 - Створити тетраедр");
            Console.WriteLine("О - вихід з програми");

            if (!int.TryParse(Console.ReadLine(), out int choice) || (choice != 1 && choice != 2 && choice != 0))
            {
                Console.WriteLine("Невірне значення. Виберіть 1, 2 або 0 для виходу.");
                continue;
            }

            if (choice == 0)
            {
                Console.WriteLine("Вихід з програми.");
                break;
            }

            if (choice == 1)
            {
                Triangle triangle = new Triangle();
                Console.WriteLine("Задання трикутника:");
                triangle.SetCoordinates();
                triangle.DisplayCoordinates();
                triangle.DisplayArea();
            }
            else if (choice == 2)
            {
                Tetrahedron tetrahedron = new Tetrahedron();
                Console.WriteLine("Задання тетраедра:");
                tetrahedron.SetCoordinates();
                tetrahedron.DisplayCoordinates();
                tetrahedron.DisplayVolume();
            }
        }
    }
}

class Triangle
{
    protected double x1, y1, x2, y2, x3, y3;

    public virtual void SetCoordinates()
    {
        Console.WriteLine("Введіть координати першої точки трикутника (x1, y1): ");
        x1 = Convert.ToDouble(Console.ReadLine());
        y1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введіть координати другої точки трикутника (x2, y2): ");
        x2 = Convert.ToDouble(Console.ReadLine());
        y2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введіть координати третьої точки трикутника (x3, y3): ");
        x3 = Convert.ToDouble(Console.ReadLine());
        y3 = Convert.ToDouble(Console.ReadLine());
    }

    public virtual void DisplayCoordinates()
    {
        Console.WriteLine($"Координати трикутника: ({x1}, {y1}), ({x2}, {y2}), ({x3}, {y3})");
    }

    public virtual double CalculateArea()
    {
        return Math.Abs((x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2.0);
    }

    public void DisplayArea()
    {
        double area = CalculateArea();
        Console.WriteLine($"Площа трикутника: {area}");
    }
}

class Tetrahedron : Triangle
{
    protected double x4, y4, z1, z2, z3, z4;


    public override void SetCoordinates()
    {
        base.SetCoordinates();

        Console.WriteLine("Введіть координати четвертої точки тетраедра (x4, y4, z4): ");
        x4 = Convert.ToDouble(Console.ReadLine());
        y4 = Convert.ToDouble(Console.ReadLine());
        z4 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введіть координати для z-координат трьох вершин (z1, z2, z3): ");
        z1 = Convert.ToDouble(Console.ReadLine());
        z2 = Convert.ToDouble(Console.ReadLine());
        z3 = Convert.ToDouble(Console.ReadLine());
    }

    public override void DisplayCoordinates()
    {
        base.DisplayCoordinates();
        Console.WriteLine($"Координати четвертої точки тетраедра: ({x4}, {y4}, {z4})");
    }

    public double CalculateVolume()
    {
        double volume = Math.Abs((x1 * (y2 * z3 + y3 * z2 + y4 * z4) - x2 * (y1 * z3 + y3 * z1 + y4 * z4) +
                                 x3 * (y1 * z2 + y2 * z1 + y4 * z4) - x4 * (y1 * z2 + y2 * z3 + y3 * z1)) / 6.0);
        return volume;
    }

    public void DisplayVolume()
    {
        double volume = CalculateVolume();
        Console.WriteLine($"Об'єм тетраедра: {volume}");
    }
}
