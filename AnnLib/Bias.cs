using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnLib
{
    class Bias : Node
    {
        #region Fields

        public readonly double Value;

        #endregion
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Bias() : this(1.0)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value"></param>
        public Bias(double value)
        {
            Value = value;
        }

        #endregion
        #region Public Methods

        public void Pulse()
        {
            InputSignal = OutputSignal = Value;

            foreach (Connection conn in NextLayer) {
                conn.Destination.Pulse(conn, Value);
            }
        }

        #endregion
    }
}
