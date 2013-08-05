using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnLib
{
    /// <summary>
    /// Input layer element
    /// </summary>
    public class FirstLayerElement
    {
        #region Fields

        public Connection[] NextLayer;
        protected double InputSignal;
        public double OutputSignal;

        #endregion
        #region Public Methods

        public virtual void Reset(Func<double> weightGenerator)
        {
            InputSignal = OutputSignal = 0;
            if (NextLayer != null) {
                foreach (Connection conn in NextLayer) {
                    conn.Weight.Reset(weightGenerator());
                }
            }
        }

        public void Insert(double value)
        {
            InputSignal = OutputSignal = value;
            foreach (Connection conn in NextLayer) {
                conn.Destination.Pulse(conn, value);
            }
        }

        #endregion
    }
}
