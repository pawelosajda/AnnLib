using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnLib
{
    public interface IActivator
    {
        double Calculate(double value);
        double Gradient(double value);
    }
}
