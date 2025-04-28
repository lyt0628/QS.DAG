using QS.DAG.Config.Model;
using QS.DAG.Core;
using QS.HierachyConfigurer;
using System;

namespace QS.DAG.Config
{
    internal class DAGraphConfigurationBuilder
                : ParentBuilderConfigurerBase<DAGraphConfiguration,
            DAGraphConfigurationBuilder,
            IDAGraphConfigurationConfigurer>, IDAGraphConfigurationConfigurer
    {
        private string _id;
        IDAGraphListener _listener;
        Func<INode, int> _prioritySelector;
        public IDAGraphConfigurationConfigurer Id(string id)
        {
            _id = id;
            return this;
        }

        public IDAGraphConfigurationConfigurer Listener(IDAGraphListener listener)
        {
            _listener = listener;
            return this;
        }

        public IDAGraphConfigurationConfigurer PrioritySelector(Func<INode, int> selector)
        {
            _prioritySelector = selector;
            return this;
        }

        protected override DAGraphConfiguration DoBuild()
        {
            return new DAGraphConfiguration(_id, _listener, _prioritySelector);
        }
    }
}
