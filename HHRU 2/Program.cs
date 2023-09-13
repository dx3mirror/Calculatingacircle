using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRU_2
{
    internal class Program
    {
        public interface IPerimeterCalculator
        {
            double CalculatePerimeter(double radius);
        }
        public class CirclePerimeterCalculator : IPerimeterCalculator
        {
            public double CalculatePerimeter(double radius)
            {
                return 2 * Math.PI * radius;
            }
        }
        public class Circle
        {
            public double Radius { get; set; }

            private readonly IPerimeterCalculator _perimeterCalculator;

            public Circle(double radius, IPerimeterCalculator perimeterCalculator)
            {
                Radius = radius;
                _perimeterCalculator = perimeterCalculator;
            }

            public double CalculatePerimeter()
            {
                return _perimeterCalculator.CalculatePerimeter(Radius);
            }
        }
        static void Main(string[] args)
        {
            var circle = new Circle(5, new CirclePerimeterCalculator());
            Console.WriteLine(circle.CalculatePerimeter());
        }
    }
}
