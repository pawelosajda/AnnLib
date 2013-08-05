using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnLib
{
    static class MultilayerPerceptronGenerator
    {
        public static MultilayerPerceptron Create(int[] layers, IActivator activator, double? biasValue)
        {
            Bias bias = biasValue.HasValue ? new Bias(biasValue.Value) : null;
            return MultilayerPerceptron(Generator(layers, activator, bias));
        }

        private static MultilayerPerceptron Generator(int[] layers, IActivator activator, Bias bias)
        {
            // przechowuje liczbę warstw
            int l = layers.Length;
            // instancjonowanie macierzy struktury sieci
            // pierwszy wymiar warstwy, drugi elementy warstwy
            List<List<Node>> structure = new ArrayList();
            // instancjonowanie obiektu konstruktora polączeń
            FullLayerConnector connector = new FullLayerConnector();
            // iterowanie po warstwach sieci, od warstwy 0 do przedostatniej
            for (int i = 0; i < l - 1; i++) {
                // jeżeli wastwa wejściowa
                if (i == 0) {
                    // instancjonowanie elementów warstwy wejściowej
                    structure.add(new ArrayList());
                    // inicjowanie warstwy wejściowej
                    for (int g = 0; g < layers[i]; g++) {
                        structure.get(i).add(new Link());
                    }
                }
                // indeks warstwy
                int j = i + 1;
                // instancjonowanie kolejnych warstw Neuronami
                structure.add(new ArrayList());
                // inicjowanie warstwy Neuronami
                for (int g = 0; g < layers[j]; g++) {
                    structure.get(j).add(new Neuron(func));
                }
                // tworzenie połączeń pomiędzy obiektami warstw sąsiednich
                connector.connect(structure.get(i), Utils.cast(structure.get(j)), bias);
            }
            // zwracanie struktury sieci
            return new NetworkStructure(structure, bias);
        }
    }
}
