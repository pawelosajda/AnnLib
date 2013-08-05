using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnLib
{
    /// <summary>
    /// Hyperbolic Tangent activation function
    /// </summary>
    class HypTanActivator : IActivator
    {
        #region IActivator Implementation

        /// <summary>
        /// Returns the hyperbolic tangent
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public double Activation(double value)
        {
            return Math.Tanh(value);
        }

        /// <summary>
        /// Returns the first derivative of the hyperbolic tangent
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public double Gradient(double value)
        {
            double activation = Activation(value);
            return 1 - activation * activation;
        }

        #endregion
    }
}
