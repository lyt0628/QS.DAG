using QS.DAG.Core;
using System;

namespace QS.DAG.Config.Model
{
    internal class NodeData
    {
        public string Id { get; }
        public Func<IDAGraphContext, bool> Guard { get; }
        public object UserData { get; }
        public bool IsEntry { get; }
        public NodeData(string id, Func<IDAGraphContext, bool> guard, object userData, bool isEntry)
        {
            this.Id = id;
            this.Guard = guard;
            UserData = userData;
            IsEntry = isEntry;
        }


    }
}
