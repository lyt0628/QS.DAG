using System;
using System.Collections.Generic;
using System.Text;

namespace QS.DAG.Config.Model
{
    internal class DAGraphModel
    {
        public ICollection<NodeData> Nodes { get; }
        public ICollection<EdgeData> Edges { get; }

        public DAGraphModel(ICollection<NodeData> nodes, ICollection<EdgeData> edges)
        {
            Nodes = nodes;
            Edges = edges;
        }

    }
}
