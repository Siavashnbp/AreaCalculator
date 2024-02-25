using AreaCalculator.Services.Shapes.Contracts.Exceptions;
using AreCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator.Entities
{
    public class Rectangle : Shape
    {
        public Rectangle(double first, double second)
        {
            FirstSide = first;
            SecondSide = second;
        }
        public double FirstSide { get; set; }
        public double SecondSide { get; set; }
        public override double CalculateArea()
        {
            return FirstSide * SecondSide;
        }
        public static bool IsValidRectangle(double first, double second)
        {
            if (first <= 0 || second <= 0)
            {
                throw new NegativeOrZeroLengthException();
            }
            if (first == second)
            {
                return false;
            }
            return true;
        }
    }
}
