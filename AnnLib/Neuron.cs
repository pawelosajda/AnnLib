using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnLib
{
    /// <summary>
    /// Standard Neuron
    /// </summary>
    class Neuron : Node
    {
        #region Fields

        private IActivator activator;

        private double pendingValue, pendingError;
        private double inputSignal;
        private int signals;

        private Connection[] previousLayer;
        private Connection[] nextLayer;

        #endregion
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Neuron() : this(new SigmoidActivator())
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="activator">activation function</param>
        public Neuron(IActivator activator)
        {
            this.activator = activator;
        }

        #endregion
        #region Public Methods

        public void Pulse(Connection sender, double value)
        {
            pendingValue += sender.Calculate(value);
            if (++signals < previousLayer.Length) {
                return;
            }
            signals = 0;
            double output = activator.Activation(pendingValue);
            inputSignal = pendingValue;

            foreach (Connection conn in nextLayer) {
                conn.Destination.Pulse(conn, output);
            }
        }

        public void BackProp(double error, double learnFactor, double momentum)
        {
            pendingError += error;
            if (++signals < nextLayer.Length) {
                return;
            }

            double gradient = activator.Gradient(inputSignal);
            double delta = pendingError * gradient;
            pendingError = signals = 0;

            foreach (Connection conn in previousLayer) {
                conn.Weight.Correct(delta);
                if (conn.Source is Neuron) {
                    conn.Source.BackProp(delta * conn.Weight.Value, learnFactor, momentum);
                }
            }
        }

        #endregion
    }
}
