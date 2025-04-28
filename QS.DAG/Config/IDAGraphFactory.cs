using QS.DAG.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace QS.DAG.Config
{
    public interface IDAGraphFactory
    {
        IDAGraph GetGraph();

    }
}
