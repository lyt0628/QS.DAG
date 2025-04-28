using QS.Reactive;
using QS.Reactive.Flow;
using System;
using System.Collections.Generic;
using System.Text;

namespace QS.DAG.Core
{
    public class SimpleNode : NodeBase
    {
        public SimpleNode(string id, Func<IDAGraphContext, bool> guard, bool isEntry, object userData) : base(id, guard, isEntry, userData)
        {
        }
    }
}
