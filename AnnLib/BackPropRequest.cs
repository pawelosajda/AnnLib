using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnLib
{
    public class BackPropRequest
    {
        static readonly Random Seed = new Random();
        readonly TrainingSet[] TrainingSet;

        public readonly int MaxEpochs;
        public readonly double MaxMSE;

        public bool ShuffleTrainingSet;

        public BackPropRequest(TrainingSet[] trainingSet, int maxEpochs)
            : this(trainingSet, maxEpochs, 0)
        {

        }

        public BackPropRequest(TrainingSet[] trainingSet, int maxEpochs, double maxMSE)
        {
            TrainingSet = trainingSet;
            MaxEpochs = maxEpochs;
            MaxMSE = maxMSE;
        }
        public IEnumerable<TrainingSet> GetTrainingData()
        {
            var toret = TrainingSet;
            if (ShuffleTrainingSet)
                toret = Shuffle(toret).ToArray();
            foreach (TrainingSet td in TrainingSet)
                yield return td;
        }

        ICollection<T> Shuffle<T>(ICollection<T> c)
        {
            T[] a = new T[c.Count];
            c.CopyTo(a, 0);
            byte[] b = new byte[a.Length];
            Seed.NextBytes(b);
            Array.Sort(b, a);
            return new List<T>(a);
        }
    }
}
