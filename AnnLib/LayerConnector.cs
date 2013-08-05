using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnLib
{
    class LayerConnector
    {
        /// <summary>
        /// Dokonuje pełnego połączenia dwóch wartw neuronów
        /// każdy z każdym
        /// </summary>
        /// <param name="prior">warstwa poprzednia</param>
        /// <param name="next">warstwa kolejna</param>
        /// <param name="bias">bias, element progowy sieci</param>
        public void Connect(FirstLayerElement[] prior, Neuron[] next, Bias bias)
        {
            // iterowanie neuronów warstwy kolejnej i wypełnianie pola previous
            foreach (Neuron neuron in next)
                neuron.PreviousLayer = GetNeuronConnections(prior, neuron, bias).ToArray();
            int idx = 0;
            // iterowanie warstwy poprzedniej
            foreach (FirstLayerElement link in prior)
                link.NextLayer = GetLinkConnections(idx++, next).ToArray();
            if (bias != null) {
                var biasConnections = GetBiasConnections(bias, next);
                if (bias.NextLayer == null)
                    bias.NextLayer = new Connection[] { };
                bias.NextLayer = bias.NextLayer.Concat(biasConnections).ToArray();
            }

        }
        /// <summary>
        /// Tworzenie połączeń z neuronami warstwy poprzedniej i biasem a neuronem 
        /// z warstwy kolejnej
        /// </summary>
        /// <param name="prior">neurony wartwy poprzedniej</param>
        /// <param name="neuron">nuron z wartwy kolejnej</param>
        /// <param name="bias">bias, element progowy</param>
        /// <returns></returns>
        IEnumerable<Connection> GetNeuronConnections(FirstLayerElement[] prior, Neuron neuron, Bias bias)
        {
            foreach (FirstLayerElement link in prior)
                yield return new Connection(link, neuron);
            if (bias != null)
                yield return new Connection(bias, neuron);
        }
        /// <summary>
        /// Pobiera połączenia z neuronów warstwy kolejnej do neuronu 
        /// warstwy poprzedniej
        /// </summary>
        /// <param name="index">indeks połączenia, neuronu warstwy poprzedniej</param>
        /// <param name="next">neurony wartwy kolejnej</param>
        /// <returns>Lista połączeń</returns>
        IEnumerable<Connection> GetLinkConnections(int index, Neuron[] next)
        {
            foreach (Neuron neuron in next)
                yield return neuron.PreviousLayer[index];
        }
        /// <summary>
        /// Podłącza element progowy do warstwy neuronów
        /// </summary>
        /// <param name="bias">element progowy</param>
        /// <param name="next">neurony wartwy kolejnej</param>
        /// <returns>lista połączeń warstwy z elementem progowym</returns>
        IEnumerable<Connection> GetBiasConnections(Bias bias, Neuron[] next)
        {
            foreach (Neuron neuron in next)
                yield return neuron.PreviousLayer[neuron.PreviousLayer.Length - 1];

        }
    }
}
