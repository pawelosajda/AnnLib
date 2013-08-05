using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnLib
{
    class NetworkStructure
    {
        public Node[] elements;
        public Node[][] layers;
        public Bias bias;

        Neuron[] cache = null;

        public Node[] getInput()
        {
            return layers[0];
        }

        public Neuron[] getOutput() 
        {
            if(cache == null) {
                cache=layers[layers.Length-1].Select(x => (Neuron)x).ToArray();
            }
            return cache;   
        }

        public NetworkStructure(Node[][] layers, Bias bias) 
        {  
            this.layers = layers;
            this.bias = bias;
            this.elements = gather(layers, bias).ToArray();
        }

        private IEnumerable<Node> gather(Node[][] layers, Bias bias) 
        {
            foreach (Node[] layer in layers) {
                foreach (Node link in layer) {
                    yield return link;
                }
            }
            if (bias != null) {
                yield return bias;
            }
            yield break;
        }
    }
}
