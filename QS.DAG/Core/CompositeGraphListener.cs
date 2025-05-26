using System.Collections.Generic;

namespace QS.DAG.Core
{
    internal class CompositeGraphListener : IDAGraphListener
    {
        private readonly IList<IDAGraphListener> _listeners;

        public CompositeGraphListener()
        {
            this._listeners = new List<IDAGraphListener>();
        }

        public void Register(IDAGraphListener listener)
        {
            if (listener != null)
            {
                _listeners.Add(listener);
            }
        }
        public void Unregister(IDAGraphListener listener)
        {
            if(listener != null)
            {
                _listeners.Remove(listener);
            }
        }

        public void OnEnd()
        {
            foreach (var listener in _listeners)
            {
                listener.OnEnd();
            }
        }

        public void OnStart()
        {
            foreach (var listener in _listeners)
            {
                listener.OnStart();
            }
        }

        public void OnVisitNode(INode currentNode, INode nextNode)
        {
            foreach (var listener in _listeners)
            {
                listener.OnVisitNode(currentNode, nextNode);
            }
        }
    }
}
