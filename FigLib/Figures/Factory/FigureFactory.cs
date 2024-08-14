using FigLib.Figures.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigLib
{
    public class FigureFactory : IFigureFactoty
    {
        private readonly TriangleFactory triangleFactory = new TriangleFactory();
        private readonly QuadrilateralFactory quadrilateralFactory = new QuadrilateralFactory();
        public Figure GetFigure(params double[] sides)
        {
            switch (sides.Length) {
                case 1:
                    return new Circle(sides[0]);
                case 3:
                    return triangleFactory.GetFigure(sides[0], sides[1], sides[2]);
                default:
                    throw new ArgumentException($"Не поддрерживается такое количество арументов ({sides.Length})");

            }
        }

        public Figure GetFigure(params Point[] points)
        {
            switch (points.Length)
            {
                case 2:
                    return new Circle(points[0], points[1]);
                case 3:
                    return triangleFactory.GetFigure(points[0], points[1], points[2]);
                case 4:
                    return quadrilateralFactory.GetFigure(points[0], points[1], points[2], points[3]);
                default:
                    throw new ArgumentException($"Не поддрерживается такое количество арументов ({points.Length})");

            }
        }
    }
}
