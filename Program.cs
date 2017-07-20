using System;

namespace ToDo_Area
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class Polygon
    {
        Point[] _points = new Point[0];        

        public void AddPoint(int x, int y)
        {            
            Array.Resize(ref _points, _points.Length + 1);
            _points[_points.Length - 1] = new Point() { X = x, Y = y };
        }

        public double Area()
        {
            double area = 0;

            if(Array.FindIndex(_points, x => x == null) == -1 && _points.Length >= 3)
            {
                AddPoint(_points[0].X, _points[0].Y);

                for (int i = 0; i < _points.Length - 1; i++)
                {
                    area += (double)(_points[i].X * _points[i + 1].Y) - (_points[i].Y * _points[i + 1].X); //адаптация алгоритма источника: http://ru.wikihow.com
                }
            }               

            return Math.Abs(area / 2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество вершин многоугольника (не менее трех): ");
            int pointsCount = int.Parse(Console.ReadLine());

            if (pointsCount < 3)
            {
                pointsCount = 3;
                Console.WriteLine("Введено недопустимое количество вершин, определено: 3");
            }                
            
            Polygon polygon = new Polygon();

            for(int i = 0; i < pointsCount; i++)
            {
                Console.Write("\n");
                Console.WriteLine("Введите координаты вершины Point {0}: ", i + 1);
                Console.Write("  x = ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("  y = ");
                int y = int.Parse(Console.ReadLine());
                polygon.AddPoint(x, y);
                Console.Write("\n");
            }

            Console.WriteLine("S многоугольника = {0}", polygon.Area());
            Console.ReadLine();
        }
    }    
}
