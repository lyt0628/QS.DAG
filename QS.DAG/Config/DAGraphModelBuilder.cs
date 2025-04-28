using QS.DAG.Config.Model;
using QS.HierachyConfigurer;
using System;
using System.Collections.Generic;
using System.Text;

namespace QS.DAG.Config
{
    internal class DAGraphModelBuilder  
        : ParentBuilderConfigurerBase<DAGraphModel, 
            DAGraphModelBuilder,
            IDAGraphModelConfigurer>, IDAGraphModelConfigurer
    {
        readonly ICollection<NodeData> _nodes;
        readonly ICollection<EdgeData> _edges;
        public DAGraphModelBuilder()
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
            if(edge != null)
            {
                _edges.Add(edge);
            }
        }
        public INodeConfigurer WithNode()
        {
            return ApplyChildConfigurer(new NodeConfigurer()); 
        }

        protected override DAGraphModel DoBuild()
        {
            return new DAGraphModel(_nodes, _edges);
        }
    }
}
