using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigLib
{
    public class RightTriangle : TriangleDecorator
    {
        public Vector Hypotenuse => Vectors.First(v => v.Length == Vectors.Max(v1 => v1.Length));
        public Vector Leg1 => Vectors.First(v => v != Hypotenuse);
        public Vector Leg2 => Vectors.First(v => v != Hypotenuse && v != Leg1);
        internal RightTriangle(Triangle triangle) : base(triangle) { }

        public RightTriangle(double leg1, double leg2) : base(CreateTriangle(leg1, leg2))
        {

        }

        private static Triangle CreateTriangle(double leg1, double leg2)
        {
            return new Triangle(new Point(0, 0), new Point(0, leg1), new Point(leg2, 0));
        }
    }
}
