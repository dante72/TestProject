using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigLib
{
    public class Quadrilateral : Polygon
    {
        public virtual Vector[] Sides => GetSides();
        public Vector[] Diameters => Vectors.Where(v => !Sides.Any(s => s == v || s == -v)).ToArray();
        public Quadrilateral(Point p1, Point p2, Point p3, Point p4) : base(p1, p2, p3, p4)
        {

        }

        protected Quadrilateral() { }

        private Vector[] GetSides()
        {
            var vectors = new List<Vector>();
            for (int i = 0; i < Points.Length; i++)
            {
                var vector = new Vector(Points[i], Points[(i + 1) % Points.Length]);
                Vector result = Vectors.ToList().FindAll(v => v == vector || v == -vector).First();
                vectors.Add(result);
            }

            return vectors.ToArray();
        }

    }
}
