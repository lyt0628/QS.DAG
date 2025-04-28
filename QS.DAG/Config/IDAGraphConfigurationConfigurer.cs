using QS.DAG.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace QS.DAG.Config
{
    public interface IDAGraphConfigurationConfigurer
    {
        IDAGraphConfigurationConfigurer Id(string id);
        IDAGraphConfigurationConfigurer Listener(IDAGraphListener listener);
        IDAGraphConfigurationConfigurer PrioritySelector(Func<INode, int> selector);
    }
}
