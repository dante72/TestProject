using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigLib.Figures.Factory
{
    internal class QuadrilateralFactory : IFigureFactoty
    {
        public Figure GetFigure(params Point[] points)
        {
            if (points.Length != 4)
            {
                throw new ArgumentException($"Параметров должно быть 4 ({points.Length})");
            }

            var q = new Quadrilateral(points[0], points[1], points[2], points[3]);
            return CreateProps(q);
        }

        private Quadrilateral CreateProps(Quadrilateral q)
        {
            if (q.IsSquard())
            {
                q = new Square(q);
            }

            if (q.IsTrapezoid())
            {
                q = new Trapezoid(q);
            }

            return q;
        }
    }
}
