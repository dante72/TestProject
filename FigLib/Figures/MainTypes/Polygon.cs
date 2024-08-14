using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigLib
{
    public class Polygon : Figure
    {
        private double? area;
        protected double[] sides;
        protected Vector[] vectors;

        public virtual Vector[] Vectors => vectors;


        public override double Area {
            get {
                if (!area.HasValue) {
                    area = GetArea();
                }

                return (double)area;
            }
        }

        public Polygon(params Point[] points) : base(points)
        {
            ToSortPoints();
            vectors = CreateVectors();
        }

        private void ToSortPoints()
        {
            for (int i = 0; i < points.Length - 2; i++) {
                int currentIndex = i + 1;
                for (int j = i + 2; j < points.Length; j++) {
                    if (points[i].Distance(points[currentIndex]) > points[i].Distance(points[j])) {
                        currentIndex = j;
                    }
                }
                Swap(ref points[currentIndex], ref points[i + 1]);
            }
        }

        private void Swap(ref Point p1, ref Point p2) {
            Point tmp = p1;
            p1 = p2;
            p2 = tmp;
        }

        protected Vector[] CreateVectors()
        {
            var vectors = new List<Vector>();
            for (int i = 0; i < points.Length - 1; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    vectors.Add(new Vector(points[j], points[i]));
                }
            }

            return vectors.ToArray();
        }

        protected double GetArea()
        {
            double area = 0;
            for (int i = 1; i < points.Length - 1; i++) {
                area += GetArea(points[0], points[i], points[i + 1]);
            }

            return area;
        }

        private double GetArea(Point p1, Point p2, Point p3) {
            double s1 = p1.Distance(p2);
            double s2 = p1.Distance(p3);
            double s3 = p2.Distance(p3);

            double p = 0.5 * (s1 + s2 + s3); //semiperimeter
            double area = Math.Sqrt(p * (p - s1) * (p - s2) * (p - s3));

            return area;
        }
    }
}
