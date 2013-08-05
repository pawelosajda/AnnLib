using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnLib
{
    /// <summary>
    /// Sigmoid Activator
    /// </summary>
    public class SigmoidActivator : IActivator
    {
        #region Fields

        /// <summary>
        /// beta factor
        /// </summary>
        private readonly double beta;

        #endregion
        #region Constructors

        public SigmoidActivator() : this(1.0)
        {

        }

        public SigmoidActivator(double beta)
        {
            this.beta = beta;
        }

        #endregion
        #region IActivator Implementation

        /// <summary>
        /// Returns value of the logistic function
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public double Activation(double value)
        {
            return 1 / (1 + Math.Pow(Math.E, -beta * value));
        }

        /// <summary>
        /// Returns value of the first derivative logistic function
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public double Gradient(double value)
        {
            double activation = Activation(value);
            return beta * activation * (1 - activation);
        }

        #endregion
    }
}
