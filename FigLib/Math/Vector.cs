using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FigLib
{
    public class Vector
    {
        public double X => Points[1].X - Points[0].X;
        public double Y => Points[1].Y - Points[0].Y;
        public double Length => Points[1].Distance(Points[0]);

        public Point[] Points;
        public Vector(double x, double y)
        {
            Points = new Point[2];
            Points[0] = new Point(0, 0);
            Points[1] = new Point(x, y);
        }

        public Vector(Point p1, Point p2)
        {
            Points = new Point[2];
            Points[0] = p2;
            Points[1] = p1;
        }

        public override string ToString() => $"({X}, {Y})";

        public static Vector operator +(Vector p1, Vector p2) => new Vector(p1.X + p2.X, p1.Y + p2.Y);
        public static Vector operator -(Vector p1, Vector p2) => new Vector(p2.X - p1.X, p2.Y - p1.Y);
        public static double operator *(Vector p1, Vector p2) => p1.X * p2.X + p1.Y * p2.Y;
        public static Vector operator -(Vector p1) => new Vector(-p1.X, -p1.Y);

        public static bool operator ==(Vector p1, Vector p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static bool operator !=(Vector p1, Vector p2)
        {
            return !(p1 == p2);
        }

        public bool IsParallel(Vector p2) => X * p2.Y - Y * p2.X == 0; 
    }
}
