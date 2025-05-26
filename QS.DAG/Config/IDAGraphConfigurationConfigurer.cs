using QS.DAG.Core;
using System;

namespace QS.DAG.Config
{
    public interface IDAGraphConfigurationConfigurer
    {
        IDAGraphConfigurationConfigurer Id(string id);
        IDAGraphConfigurationConfigurer Listener(IDAGraphListener listener);
        IDAGraphConfigurationConfigurer PrioritySelector(Func<INode, int> selector);
    }
}
