using Newtonsoft.Json.Linq;
using System;
using Xunit;
using static CalcAreaFigure.Triangle;

namespace CalcAreaFigure.Tests
{
    public class CalcAreaFigureTests
    {
        public class CircleTests
        {
            [InlineData(1, 3.14)]
            [InlineData(5, 78.54)]
            [Theory]
            public void Correct_Result_Calculation_Area_Figure(double radius, double expected)
            {
                // Arrange
                var circle = new Circle(radius);

                // Act
                double result = circle.CalcArea();

                // Assert
                Assert.Equal(expected, result, 2);
            }

            [InlineData(0)]
            [InlineData(-5)]
            [Theory]
            public void Incoming_Values_Are_Equal_Or_Less_Than_Zero(double radius)
            {
                // Arrange
                var circle = new Circle(1);

                // Act
                void action() => circle.Radius = radius;

                // Assert
                Assert.Throws<ValuesEqualOrLessZero>(action);
            }
        }

        public class TriangleTests
        {
            [InlineData(3, 3, 3, 3.9)]
            [Theory]
            public void Correct_Result_Calculation_Area_Figure(double sideA, double sideB, double sideC, double expected)
            {
                // Arrange
                var triangle = new Triangle(sideA, sideB, sideC);

                // Act
                double result = triangle.CalcArea();

                // Assert
                Assert.Equal(expected, result, 2);
            }

            [InlineData(4, 5, 3, true)]
            [InlineData(6, 6, 6, false)]
            [Theory]
            public void Is_Triangle_Rectangular(double sideA, double sideB, double sideC, bool expected)
            {
                // Arrange
                var triangle = new Triangle(sideA, sideB, sideC);

                // Act
                bool result = triangle.IsRectangular;

                // Assert
                Assert.Equal(expected, result);
            }

            [InlineData(1, 1, 5)]
            [Theory]
            public void Changing_The_Size_Of_The_Sides_Of_An_Existing_Triangle(double sideA, double sideB, double sideC)
            {
                // Arrange
                var triangle = new Triangle(4, 5, 3);

                // Act
                void action() {
                    triangle.SideA = sideA;
                    triangle.SideB = sideB;
                    triangle.SideC = sideC;
                }

                // Assert
                Assert.Throws<TriangleCannotExist>(action);
            }
        }
    }
}