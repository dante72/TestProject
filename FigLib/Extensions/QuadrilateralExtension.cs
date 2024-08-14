using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigLib
{
    public static class QuadrilateralExtension
    {
        public static bool IsSquard(this Quadrilateral q)
        {
            return q.Sides[0] * q.Sides[1] == 0 && q.Diameters[0] * q.Diameters[1] == 0;
        }

        public static bool IsTrapezoid(this Quadrilateral q)
        {
            var parallelVectors = q.Vectors.Where(s1 => q.Vectors.Any(s2 => s2 != s1 && s1.IsParallel(s2))).Take(2).ToArray();

            return parallelVectors.Length == 2;
        }

        public static T CheckType<T>(this Quadrilateral q) where T : QuadrilateralDecorator
        {
            if (q is QuadrilateralDecorator qd)
                return qd.CheckType<T>();
            else
                return null;
        }

    }
}
