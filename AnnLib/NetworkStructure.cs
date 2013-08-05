using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnLib
{
    public class NetworkStructure
    {
        #region Fields

        public FirstLayerElement[] Elements;
        public FirstLayerElement[][] Layers;
        public Bias Bias;

        Neuron[] cache = null;

        public FirstLayerElement[] Input {
            get { return Layers[0]; }
        }

        public Neuron[] Output {
            get
            {
                if (cache == null) {
                    cache = Layers[Layers.Length - 1].Select(x => (Neuron)x).ToArray();
                }
                return cache;
            }
        }

        #endregion
        #region Constructor

        public NetworkStructure(FirstLayerElement[][] layers, Bias bias) 
        {  
            this.Layers = layers;
            this.Bias = bias;
            this.Elements = gather(layers, bias).ToArray();
        }

        #endregion


        private IEnumerable<FirstLayerElement> gather(FirstLayerElement[][] layers, Bias bias) 
        {
            foreach (FirstLayerElement[] layer in layers) {
                foreach (FirstLayerElement link in layer) {
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
