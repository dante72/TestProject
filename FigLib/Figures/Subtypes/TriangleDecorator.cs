using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigLib
{
    public abstract class TriangleDecorator : Triangle
    {
        protected Triangle triangle;

        public TriangleDecorator(Triangle triangle)
        {
            this.triangle = triangle;
        }
        public override double[] Sides => triangle.Sides;
        public override double Area => triangle.Area;
        public override Point[] Points => triangle.Points;
        public override Vector[] Vectors => triangle.Vectors;

        public T CheckType<T>() where T : TriangleDecorator
        {
            if (GetType() == typeof(T))
                return (T)this;
            else if (triangle is TriangleDecorator tr)
                return tr.CheckType<T>();
            else
                return null;
        }
    }
}
