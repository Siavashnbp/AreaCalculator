using AreaCalculator.Entities;
using AreaCalculator.Services.Shapes.Contracts.Exceptions;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace AreaCalculatorUnit.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(true, 2, 2.2, 3)]
        [InlineData(true, 2, 5, 6)]
        [InlineData(false, 2, 5, 7)]
        [InlineData(false, 1, 5, 2)]
        public void IsValidTriangle_returns_true_on_valid_lenghts
            (bool expected, double first, double second, double third)
        {
            var actual = Triangle.IsValidTriangle(first, second, third);

            actual.Should().Be(expected);

        }
        [Theory]
        [InlineData(6, 3, 4, 5)]
        public void Triangle_CalculateArea_returns_area_of_triangle_on_valid_lengths
            (double expected, double first, double second, double third)
        {
            var triangle = new Triangle(first, second, third);

            var actual = triangle.CalculateArea();

            actual.Should().Be(expected);
        }
        [Fact]
        public void IsValidTriangle_throws_exception_on_negative_or_zero_inputs()
        {
            var first = 2;
            var second = -3;
            var third = 4;

            var actual = () => Triangle.IsValidTriangle(first, second, third);

            actual.Should().ThrowExactly<NegativeOrZeroLengthException>();
        }
        [Fact]
        public void IsValidSqure_returns_true_on_positive_inputs()
        {
            var side = 4.2;
            var expected = true;

            var actual = Square.IsValidSquare(side);

            actual.Should().Be(expected);
        }
        [Fact]
        public void IsValidSquare_throws_NegativeOrZeroException_on_negative_or_zero_inputs()
        {
            var side = 0;

            var actual = () => Square.IsValidSquare(side);

            actual.Should().ThrowExactly<NegativeOrZeroLengthException>();
        }
        [Theory]
        [InlineData(25, 5)]
        [InlineData(100, 10)]
        public void Square_CalculateArea_returns_area_of_square(double expected, double side)
        {
            var square = new Square(side);

            var actual = square.CalculateArea();

            actual.Should().Be(expected);
        }
        [Theory]
        [InlineData(true, 4, 5)]
        [InlineData(false, 4, 4)]
        public void IsValidRectangle_returns_true_on_proper_positive_inputs
            (bool expected, double first, double second)
        {
            var actual = Rectangle.IsValidRectangle(first, second);

            actual.Should().Be(expected);
        }
        [Fact]
        public void IsValidRectangle_throws_NegativeOrZeroException_on_negative_or_zero_inputs()
        {
            var first = -7;
            var second = 8;

            var actual = () => Rectangle.IsValidRectangle(first, second);

            actual.Should().ThrowExactly<NegativeOrZeroLengthException>();
        }
        [Theory]
        [InlineData(30, 5, 6)]
        [InlineData(15, 10, 1.5)]
        public void Rectangle_CalculateArea_returns_area_of_rectangle
            (double expected, double first, double second)
        {
            var rectangle = new Rectangle(first,second);

            var actual = rectangle.CalculateArea();

            actual.Should().Be(expected);
        }
    }
}