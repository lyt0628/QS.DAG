using System;

namespace QS.DAG.Core
{
    public abstract class NodeBase : INode
    {
        public string Id { get; }

        public NodeBase(string id, Func<IDAGraphContext, bool> guard, bool isEntry, object userData)
        {
            Id = id;
            Guard = guard;
            IsEntry = isEntry;
            UserData = userData;
        }
        public object UserData { get; }
        public Func<IDAGraphContext, bool> Guard { get; }
        public bool IsEntry { get; set; }
    }
}
