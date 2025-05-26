using System;

namespace QS.DAG.Core
{
    public class SimpleNode : NodeBase
    {
        public SimpleNode(string id, Func<IDAGraphContext, bool> guard, bool isEntry, object userData) : base(id, guard, isEntry, userData)
        {
        }
    }
}
