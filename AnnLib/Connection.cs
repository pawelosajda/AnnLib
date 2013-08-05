using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnLib
{
    public class Connection
    {
        #region Fields
        /// <summary>
        /// Weight
        /// </summary>
        public readonly Weight Weight;

        /// <summary>
        /// Source of the signal
        /// </summary>
        public readonly FirstLayerElement Source;

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
        public Connection(FirstLayerElement source, Neuron destination) 
            : this(source, destination, new Weight())
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="source">source neuron</param>
        /// <param name="destination">destination neuron</param>
        /// <param name="weight">weight of the connection</param>
        public Connection(FirstLayerElement source, Neuron destination, Weight weight)
        {
            this.Source = source;
            this.Destination = destination;
            this.Weight = weight;
        }

        #endregion
    }
}
