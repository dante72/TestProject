using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigLib.Figures.Factory
{
    internal interface IFigureFactoty
    {
        Figure GetFigure(params Point[] points);
    }
}
