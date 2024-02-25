using AreaCalculator.Services.Shapes.Contracts.Exceptions;
using AreCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator.Entities
{
    public class Square : Shape
    {
        public Square(double side)
        {
            SideLength = side;
        }
        public double SideLength { get; set; }
        public override double CalculateArea()
        {
            return Math.Pow(SideLength, 2);
        }
        public static bool IsValidSquare(double side)
        {
            if (side <= 0)
            {
                throw new NegativeOrZeroLengthException();
            }
            return true;
        }
    }
}
