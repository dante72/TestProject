using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigLib
{
    public class IsoscelesTriangle : TriangleDecorator
    {
        public Vector Side1 => Vectors.First(v1 => Vectors.Any(v2 => v1 != v2 && v1.Length == v2.Length));
        public Vector Side2 => Vectors.First(v1 => v1 != Side1 && v1.Length == Side1.Length);
        public Vector Base => Vectors.First(v => v != Side1 && v != Side2);
        internal IsoscelesTriangle(Triangle triangle) : base(triangle)
        {
        }

        public IsoscelesTriangle(double side, double foundation) : this(CreateTriangle(side, foundation))
        {

        }

        private static Triangle CreateTriangle(double side, double foundation)
        {
            return new Triangle(side, side, foundation);
        }
    }
}
