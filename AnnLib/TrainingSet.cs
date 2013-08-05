using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnLib
{
    public class TrainingSet
    {
        #region Fields

        public readonly double[] Input;
        public readonly double[] Output;

        #endregion
        #region Constructor

        public TrainingSet(double[] input, double[] output)
        {
            Input = input;
            Output = output;
        }

        #endregion


    }
}
