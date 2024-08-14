using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigLib
{
    public abstract class Figure
    {
        protected Point[] points;
        public abstract double Area
        {
            get;
        }

        public virtual Point[] Points
        {
            get => points;
        }

        public Figure(params Point[] points)
        {
            this.points = points; 
        }
    }
}
