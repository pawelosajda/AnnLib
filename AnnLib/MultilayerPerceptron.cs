using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnLib
{
    public class MultilayerPerceptron
    {
        #region Fields

        static readonly Random Rnd = new Random();
        public double Momentum;
        public double LearnFactor;
        public readonly NetworkStructure Structure;

        #endregion
        #region Constructors

        public MultilayerPerceptron(NetworkStructure structure)
        {
            Structure = structure;
        }

        public MultilayerPerceptron(NetworkStructure structure, double lo, double hi) : this(structure)
        {
            Reset(lo, hi);
        }

        #endregion
        #region Public Methods

        public double[] Pulse(double[] values)
        {
            if (Structure.Bias != null) {
                Structure.Bias.Pulse();
            }
            for (int i = 0; i != values.Length; i++) {
                Structure.Input[i].Insert(values[i]);
            }
            return Structure.Output.Select(x => x.OutputSignal).ToArray();
        }

        public bool BackProp(BackPropRequest bpr)
        {
            Neuron[] output = Structure.Output;

            for (int i = 0; i < bpr.MaxEpochs; i++) {
                bool allPassed = true;

                TrainingSet[] ts = bpr.GetTrainingData().ToArray();
                List<double> errors = new List<double>(ts.Length);

                for (int j = 0; j < ts.Length; j++) {
                    double mse = GetMeanSquareError(ts[j].Input, ts[j].Output);
                    errors.Add(mse);

                    if (mse > bpr.MaxMSE) {
                        for (var k = 0; k != output.Length; k++)
                            ((Neuron)output[k]).BackProp(ts[j].Output[k] - output[k].OutputSignal, LearnFactor, Momentum);
                        allPassed = false;
                    }
                }

                if (allPassed) {
                    return true;
                }
                
            }
            return false;
        }

        #endregion
        #region Private Methods

        private double GetMeanSquareError(double[] input, double[] sample)
        {
            double sum = 0;
            for (int i = 0; i < input.Length; i++) {
                sum += Math.Pow(sample[i] - input[i], 2);
            }
            return sum / 2;
            //return Math.Sqrt(sum/sample.Length);
        }

        public void Reset(Func<double> weightGenerator)
        {
            foreach (FirstLayerElement node in Structure.Elements)
                node.Reset(weightGenerator);
        }

        public void Reset(double lo, double hi)
        {
            Reset(() => (hi - lo) * Rnd.NextDouble() + lo);
        }

        #endregion
    }
}
