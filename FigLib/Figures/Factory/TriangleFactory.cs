using FigLib.Figures.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigLib
{
    internal class TriangleFactory : IFigureFactoty
    {
        public Figure GetFigure(params double[] sides)
        {
            if (sides.Length != 3)
            {
                throw new ArgumentException($"Параметров должно быть 3 ({sides.Length})");
            }

            var triangle = new Triangle(sides[0], sides[1], sides[2]);
            return CreateProps(triangle);
        }

        public Figure GetFigure(params Point[] points)
        {
            if (points.Length != 3)
            {
                throw new ArgumentException($"Параметров должно быть 3 ({points.Length})");
            }

            var triangle = new Triangle(points[0], points[1], points[2]);
            return CreateProps(triangle);
        }

        private Triangle CreateProps(Triangle triangle)
        {
            if (triangle.IsRight())
            {
                triangle = new RightTriangle(triangle);
            }

            if (triangle.IsIsosceles())
            {
                triangle = new IsoscelesTriangle(triangle);
            }

            if (triangle.IsEquilateral())
            {
                triangle = new EquilateralTriangle(triangle);
            }

            return triangle;
        }
    }
}
