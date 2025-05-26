using QS.DAG.Core;
using System;

namespace QS.DAG.Config.Model
{
    internal class DAGraphConfiguration
    {
        public string Id { get; }

        public DAGraphConfiguration(string id, IDAGraphListener listener, Func<INode, int> prioritySelector)
        {
            Id = id;
            this.Listener = listener;
            PrioritySelector = prioritySelector;
        }

        public IDAGraphListener Listener { get; }
        public Func<INode, int> PrioritySelector { get; }

    }
}
