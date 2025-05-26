using QS.DAG.Core;
using System.Collections.Generic;
using System.Linq;

namespace QS.DAG.Config
{
    internal class DAGraphFactory : IDAGraphFactory
    {
        private readonly DAGraphConfigBuilder _configBuilder;

        public DAGraphFactory(DAGraphConfigBuilder configBuilder)
        {
            _configBuilder = configBuilder;
        }

        public IDAGraph GetDAGraph()
        {
            var config = _configBuilder.Build();

            var configuration = config.GraphConfiguration;
            var dagId = configuration.Id;
            var listener = configuration.Listener;
            var prioritySelector = configuration.PrioritySelector;
            var model = config.GraphStructure;
            var nodes = model.Nodes.Select(nodeData =>
            {
                var id = nodeData.Id;
                var guard = nodeData.Guard;
                var userData = nodeData.UserData;
                return new SimpleNode(id, guard, true, userData);
            }).ToList();

            var idIndexPairs = new Dictionary<string, int>();
            for (int i = 0; i < nodes.Count; i++)
            {
                SimpleNode node = nodes[i];
                if (node.Id != null)
                {
                    idIndexPairs.Add(node.Id, i);
                }
            }


            var edges = model.Edges
                .GroupBy(edge => edge.Prev)
                .Aggregate(new Dictionary<int, IEnumerable<int>>(), (dict, edgeDatas) =>
                {
                    var prevIndex = idIndexPairs[edgeDatas.Key];

                    dict.Add(prevIndex,
                            edgeDatas
                                .Select(edgeData => edgeData.Next)
                                .Select(nextId => idIndexPairs[nextId]));
                    return dict;
                });
            edges.Values.SelectMany(data => data)
                .ToList()
                .ForEach(noEntry => nodes[noEntry].IsEntry = false);

            var g = new DAGraph(dagId, nodes.Cast<INode>().ToList(), edges, prioritySelector);
            g.AddListener(listener);
            return g;
        }
    }
}
