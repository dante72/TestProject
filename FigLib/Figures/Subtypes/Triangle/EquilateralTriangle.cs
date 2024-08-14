using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigLib
{
    public class EquilateralTriangle : TriangleDecorator
    {
        public double Side => Vectors[0].Length;
        internal EquilateralTriangle(Triangle triangle) : base(triangle)
        {
        }

        public EquilateralTriangle(double side) : this(CreateTriangle(side))
        {

        }

        private static Triangle CreateTriangle(double side)
        {
            return new Triangle(side, side, side);
        }
    }
}
