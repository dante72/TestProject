using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigLib
{
    public class Triangle : Polygon
    {
        public virtual double[] Sides => vectors.Select(v => v.Length).ToArray();
        public Triangle(double s1, double s2, double s3)
        {
            sides = new double[3] { s1, s2, s3 };

            if (!IsExists()) {
                throw new ArgumentException("Треугольник с такими сторонами не существует!");
            }

            double cos_s3 = (s1 * s1 + s2 * s2 - s3 * s3) / (2 * s1 * s2);
            double s1_s3_X = s1 * cos_s3;
            double s1_s3_Y = s1 * Math.Sin(Math.Acos(cos_s3));
            points = new Point[3] { new Point(0, 0), new Point(s2, 0), new Point(s1_s3_X, s1_s3_Y) };
            vectors = CreateVectors();
        }

        protected Triangle() {}

        public Triangle(Point p1, Point p2, Point p3) : base(p1, p2, p3) {

        }

        private bool IsExists()
        {
            for (int i = 0; i < sides.Length; i++) {
                if (sides[i] + sides[(i + 1) % 3] < sides[(i + 2) % 3]) {
                    return false;
                }
            }

            return true;
        }

    }
}
