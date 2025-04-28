using QS.DAG.Core;
using QS.HierachyConfigurer;
using System;
using System.Collections.Generic;
using System.Text;

namespace QS.DAG.Config
{
    public interface INodeConfigurer 
        : IChildConfigurer<IDAGraphModelConfigurer>
    {
        INodeConfigurer Id(string id);
        INodeConfigurer UserData(object data);
        INodeConfigurer Guard(Func<IDAGraphContext, bool> guard);
        INodeConfigurer WithNext(string targetId);
        INodeConfigurer WithNext();
    }
}
