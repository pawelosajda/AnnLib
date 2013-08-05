using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnLib
{
    /// <summary>
    /// Weight of the connection
    /// </summary>
    class Weight
    {
        #region Fields

        /// <summary>
        /// Weight
        /// </summary>
        public double Value { get; private set; }

        /// <summary>
        /// Change of the last correction
        /// </summary>
        private double change;

        #endregion
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Weight()
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="weight">connection weight</param>
        public Weight(double weight)
        {
            value = weight;
        }

        #endregion
        #region Public Methods

        public void Reset(double weight)
        {
            change = 0.0;
            Value = weight;
        }

        public void Correct(double delta)
        {
            change = delta;
            Value += delta;
        }

        #endregion
    }
}
