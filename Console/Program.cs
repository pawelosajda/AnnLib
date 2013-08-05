using AnnLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] layers = { 1, 10, 1 };
            var net = MultilayerPerceptronGenerator.Create(layers, new SigmoidActivator(), 1);
            net.Momentum = 0.5;
            net.LearnFactor = 0.5;
            net.Reset(-1, 1);

            double[][] input = {
                new double[] { 0.2 },
                new double[] { 0.8 },
            };

            double[][] output = {
                new double[] { 0.2 },
                new double[] { 0.8 },
            };

            List<TrainingSet> trainingList = new List<TrainingSet>();
            for (int i = 0; i < input.Length; i++) {
                trainingList.Add(new TrainingSet(input[i], output[i]));
            }

            var bpr = net.BackProp(new BackPropRequest(trainingList.ToArray(), 1000, 0.01));
            double[] result = net.Pulse(new double[] { 0.5 });

            System.Console.WriteLine(result[0].ToString());
            System.Console.ReadKey();
        }
    }
}
