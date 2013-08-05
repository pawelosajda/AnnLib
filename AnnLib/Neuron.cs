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
    public class Neuron : FirstLayerElement
    {
        #region Fields

        private IActivator Activator;

        private double PendingValue, PendingError;
        private int SignalCounter;

        public Connection[] PreviousLayer;

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
            this.Activator = activator;
        }

        #endregion
        #region Public Methods

        public void Pulse(Connection sender, double value)
        {
            PendingValue += sender.Weight.Value * value;

            if (++SignalCounter < PreviousLayer.Length) {
                return;
            }
            SignalCounter = 0;

            double output = Activator.Calculate(PendingValue);
            InputSignal = PendingValue;
            OutputSignal = output;
            if (NextLayer != null) {
                foreach (Connection conn in NextLayer) {
                    conn.Destination.Pulse(conn, output);
                }
            }
            PendingValue = 0;
        }

        public void BackProp(double error, double learnFactor, double momentum)
        {
            PendingError += error;
            if (NextLayer != null && ++SignalCounter < NextLayer.Length) {
                return;
            }

            double delta = PendingError * Activator.Gradient(InputSignal);
            PendingError = SignalCounter = 0;

            foreach (Connection conn in PreviousLayer) {
                conn.Weight.Correct(delta * conn.Source.OutputSignal * learnFactor + momentum * conn.Weight.Change);
                if (conn.Source is Neuron) {
                    ((Neuron)conn.Source).BackProp(delta * conn.Weight.Value, learnFactor, momentum);
                }
            }
        }

        #endregion
    }
}
