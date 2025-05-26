using QS.DAG.Config.Model;
using QS.HierachyConfigurer;
using System.Collections.Generic;

namespace QS.DAG.Config
{
    internal class DAGraphStructureDataBuilder
        : ParentBuilderConfigurerBase<DAGraphStructureData,
            DAGraphStructureDataBuilder,
            IDAGraphModelConfigurer>, IDAGraphModelConfigurer
    {
        readonly ICollection<NodeData> _nodes;
        readonly ICollection<EdgeData> _edges;
        public DAGraphStructureDataBuilder()
        {
            _nodes = new List<NodeData>();
            _edges = new List<EdgeData>();
        }

        public void AddNode(NodeData node)
        {
            if (node != null)
            {
                _nodes.Add(node);
            }
        }
        public void AddEdge(EdgeData edge)
        {
            if (edge != null)
            {
                _edges.Add(edge);
            }
        }
        public INodeConfigurer WithNode()
        {
            return ApplyChildConfigurer(new NodeConfigurer());
        }

        protected override DAGraphStructureData DoBuild()
        {
            return new DAGraphStructureData(_nodes, _edges);
        }
    }
}
