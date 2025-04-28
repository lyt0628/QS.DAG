using System;
using System.Collections.Generic;
using System.Text;

namespace QS.DAG.Core
{
    public class DAGraph : DAGraphBase
    {
        public DAGraph(string id, IList<INode> nodes, IDictionary<int, IEnumerable<int>> edges, Func<INode, int> prioritySelector) : base(id, nodes, edges, prioritySelector)
        {
        }
    }
}
