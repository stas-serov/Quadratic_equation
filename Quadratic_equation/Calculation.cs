using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadratic_equation
{
    public class Calculation
    {
        private double d;
        public double[] calculation (double a, double b, double c)
        {
            d = b * b - 4 * a * c;
            if(d>0) return new double[] {((-b+Math.Sqrt(d))/(2*a)), ((-b-Math.Sqrt(d))/(2*a))};
            else if(d<0) return new double[] {Convert.ToDouble(null), Convert.ToDouble(null)};
            else return new double[] { -b / (2 * a), -b / (2 * a) };
        }
    }
}
