using System;
using System.Collections.Generic;
using System.Text;

namespace QS.DAG.Core
{
    public class DAGraphListenerAdapter : IDAGraphListener
    {
        public virtual void OnEnd()
        {
        }

        public virtual void OnStart()
        {
        }

        public virtual void OnVisitNode(INode currentNode, INode nextNode)
        {
            throw new NotImplementedException();
        }
    }
}
