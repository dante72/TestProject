using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigLib
{
    public class Trapezoid : QuadrilateralDecorator
    {
        public Vector[] Legs => Vectors.Except(Diameters.Concat(Bases)).ToArray();
        public Vector[] Bases => Vectors.Where(s1 => Vectors.Any(s2 => s2 != s1 && s1.IsParallel(s2))).Take(2).ToArray();
        public Trapezoid(Quadrilateral quadrilateral) : base(quadrilateral)
        {

        }
    }
}
