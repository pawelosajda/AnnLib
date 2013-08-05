using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnLib
{
    class Node
    {
        #region Fields

        protected Connection[] NextLayer;
        protected double InputSignal;
        protected double OutputSignal;

        #endregion
    }
}
