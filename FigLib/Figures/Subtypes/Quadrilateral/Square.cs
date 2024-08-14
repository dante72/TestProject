using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigLib
{
    public class Square : QuadrilateralDecorator
    {
        public double Side => Vectors[0].Length;
        public Square(Quadrilateral quadrilateral) : base(quadrilateral)
        {
        }
    }
}
