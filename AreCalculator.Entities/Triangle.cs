using AreaCalculator.Services.Shapes.Contracts.Exceptions;
using AreCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator.Entities
{
    public class Triangle : Shape
    {
        public Triangle(double first, double second, double third)
        {
            FirstLength = first;
            SecondLength = second;
            ThirdLength = third;
        }
        public double FirstLength { get; set; }
        public double SecondLength { get; set; }
        public double ThirdLength { get; set; }
        public override double CalculateArea()
        {
            var s = (FirstLength + SecondLength + ThirdLength) / 2;
            return Math.Sqrt(s * (s - FirstLength) * (s - SecondLength) * (s - ThirdLength));
        }
        public static bool IsValidTriangle(double first, double second, double third)
        {
            if (first <= 0 || second <= 0 || third <= 0)
            {
                throw new NegativeOrZeroLengthException();
            }
            if (first + second <= third)
            {
                return false;
            }
            if (second + third <= first)
            {
                return false;
            }
            if (first + third <= second)
            {
                return false;
            }
            return true;
        }
    }
}
