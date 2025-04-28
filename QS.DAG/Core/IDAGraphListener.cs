using System;
using System.Collections.Generic;
using System.Text;

namespace QS.DAG.Core
{

    public interface IDAGraphListener
    {
        void OnStart();
        void OnVisitNode(INode currentNode, INode nextNode);
        void OnEnd();
    }
}
