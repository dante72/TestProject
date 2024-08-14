using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigLib
{
    public class QuadrilateralDecorator : Quadrilateral
    {
        protected Quadrilateral quadrilateral;

        public QuadrilateralDecorator(Quadrilateral quadrilateral)
        {
            this.quadrilateral = quadrilateral;
        }
        public override Vector[] Sides => quadrilateral.Sides;
        public override double Area => quadrilateral.Area;
        public override Point[] Points => quadrilateral.Points;
        public override Vector[] Vectors => quadrilateral.Vectors;

        public T CheckType<T>() where T : QuadrilateralDecorator
        {
            if (GetType() == typeof(T))
                return (T)this;
            else if (quadrilateral is QuadrilateralDecorator q)
                return q.CheckType<T>();
            else
                return null;
        }
    }
}
