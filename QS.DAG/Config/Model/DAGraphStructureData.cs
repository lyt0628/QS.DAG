using System.Collections.Generic;

namespace QS.DAG.Config.Model
{
    internal class DAGraphStructureData
    {
        public ICollection<NodeData> Nodes { get; }
        public ICollection<EdgeData> Edges { get; }

        public DAGraphStructureData(ICollection<NodeData> nodes, ICollection<EdgeData> edges)
        {
            Nodes = nodes;
            Edges = edges;
        }

    }
}
