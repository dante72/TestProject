using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigLib
{
    public class Circle : Figure
    {
        public readonly double radius;
        public Circle(Point p1, Point p2) : base(p1, p2)
        {
            radius = p1.Distance(p2);
        }

        public Circle(Point p1, double radius) : base(p1, new Point(p1.X + radius, p1.Y))
        {
            this.radius = radius;
        }

        public Circle(double radius) : this(new Point(0, 0), radius)
        {

        }

        public override double Area
        {
            get
            {
                return Math.PI * Math.Pow(points[0].Distance(points[1]), 2);
            }
        }
    }
}
