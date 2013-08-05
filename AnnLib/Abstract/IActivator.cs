using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnLib
{
    interface IActivator
    {
        double Activation(double value);
        double Gradient(double value);
    }
}
