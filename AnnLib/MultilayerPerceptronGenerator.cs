using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnLib
{
    public static class MultilayerPerceptronGenerator
    {
        public static MultilayerPerceptron Create(int[] layers, IActivator activator, double? biasValue)
        {
            Bias bias = biasValue.HasValue ? new Bias(biasValue.Value) : null;
            // przechowuje liczbę warstw
            int l = layers.Length;
            // instancjonowanie macierzy struktury sieci
            // pierwszy wymiar warstwy, drugi elementy warstwy
            FirstLayerElement[][] structure = new FirstLayerElement[l][];
            // instancjonowanie obiektu konstruktora polączeń
            LayerConnector connector = new LayerConnector();
            // iterowanie po warstwach sieci, od warstwy 0 do przedostatniej
            for (int i = 0; i < l - 1; i++) {
                // jeżeli wastwa wejściowa
                if (i == 0) {
                    // instancjonowanie elementów warstwy wejściowej
                   structure[i] = Generate<FirstLayerElement>(layers[i]).ToArray();
                }
                // indeks warstwy
                int j = i + 1;
                structure[j] = Generate<Neuron>(layers[j]).ToArray();
                // tworzenie połączeń pomiędzy obiektami warstw sąsiednich
                connector.Connect(structure[i], structure[j].Select(p => (Neuron)p).ToArray(), bias);
            }
            return new MultilayerPerceptron(new NetworkStructure(structure, bias));
        }

        private static IEnumerable<T> Generate<T>(int count) where T : new()
        {
            for (int i = 0; i < count; i++)
                yield return new T();
        }
    }
}
