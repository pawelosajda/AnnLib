using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnLib
{
    /// <summary>
    /// Connection weight
    /// </summary>
    public class Weight
    {
        #region Fields

        /// <summary>
        /// Weight
        /// </summary>
        public double Value { get; private set; }

        /// <summary>
        /// Change of the last correction
        /// </summary>
        public double Change;

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
            Value = weight;
        }

        #endregion
        #region Public Methods

        public void Reset(double weight)
        {
            Change = 0.0;
            Value = weight;
        }

        public void Correct(double delta)
        {
            Change = delta;
            Value += delta;
        }

        #endregion
    }
}
