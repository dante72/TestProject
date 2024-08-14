using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FigLib
{
    public static class TriangleExtension
    {
        public static bool IsRight(this Triangle triangle)
        {
            var vectors = triangle.Vectors;

            for (int i = 0; i < vectors.Length; i++)
            {
                var v1 = vectors[i];
                var v2 = vectors[(i + 1) % vectors.Length];

                if (v1 * v2 == 0)
                    return true;
            }

            return false;
        }

        public static bool IsIsosceles(this Triangle triangle)
        {
            return triangle.IsEqualSides(1);
        }


        public static bool IsEquilateral(this Triangle triangle)
        {
            return triangle.IsEqualSides(2);
        }

        private static bool IsEqualSides(this Triangle triangle, int countSides)
        {
            int n = 0;
            var sides = triangle.Sides;

            for (int i = 0; i < sides.Length - 1; i++)
            {
                if (sides[i] == sides[i + 1])
                    n++;
                
                if (n == countSides)
                    return true;
            }

            return false;
        }

        public static T CheckType<T>(this Triangle triangle) where T : TriangleDecorator
        {
            if (triangle is TriangleDecorator tr)
                return tr.CheckType<T>();
            else
                return null;
        }
    }
}
