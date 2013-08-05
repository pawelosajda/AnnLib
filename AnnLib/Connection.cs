using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnLib
{
    class Connection
    {
        #region Fields
        /// <summary>
        /// Weight
        /// </summary>
        public readonly Weight Weight;

        /// <summary>
        /// Source of the signal
        /// </summary>
        public readonly Neuron Source;

        /// <summary>
        /// Destination of the signal
        /// </summary>
        public readonly Neuron Destination;

        #endregion
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="source">source neuron</param>
        /// <param name="destination">destination neuron</param>
        /// <param name="weight">weight of the connection</param>
        public Connection(Neuron source, Neuron destination, Weight weight)
        {
            this.Source = source;
            this.Destination = destination;
            this.Weight = weight;
        }

        #endregion
        #region Public Methods

        /// <summary>
        /// Returns value of the connection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public double Calculate(double value)
        {
            return Weight.Value * value;
        }

        #endregion
    }
}
