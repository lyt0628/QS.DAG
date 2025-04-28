using QS.Reactive;
using QS.Reactive.Flow;
using QS.Reactive.Mon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace QS.DAG.Core
{
    public abstract class DAGraphBase : IDAGraph
    {

        public string Id { get; }
        public bool Linear => _edges == null;
        public DAGraphBase(string id, IList<INode> nodes, IDictionary<int, IEnumerable<int>> edges, Func<INode, int> prioritySelector)
        {
            Id = id;
            _nodes = nodes;
            _edges = edges;
            _listener = new CompositeGraphListener();
            this.prioritySelector = prioritySelector;
        }
        private Func<INode, int> prioritySelector;
        /// <summary>
        /// 节点
        /// </summary>
        readonly IList<INode> _nodes;
        /// <summary>
        /// 邻接矩阵
        /// </summary>
        readonly IDictionary<int, IEnumerable<int>> _edges;

        /// <summary>
        /// 当前节点的下标
        /// </summary>
        int _index = -1;
        readonly CompositeGraphListener _listener;

        public bool IsStarted()
        {
            return _index != -1;
        }

        public INode GetCurrentNode()
        {
            if (!IsStarted() || IsCompleted())
            {
                return null;
            }
            return _nodes[_index];
        }

        public bool InLastNode()
        {
            if (!IsStarted() || IsCompleted())
            {
                return false;
            }

            if (Linear)
            {
                return _index == _nodes.Count - 1;
            }
            else
            {
                return !_edges.ContainsKey(_index);
            }
        }
        public INode[] GetSuccessNodes()
        {
            return GetSuccessNodes(_index);

        }

        private INode[] GetSuccessNodes(int index)
        {
            if (!IsStarted() || IsCompleted())
            {
                return null;
            }
            if (Linear)
            {
                if (index == _nodes.Count - 1)
                {
                    return null;
                }
                return new INode[]
                {
                        _nodes[index + 1]
                };
            }
            else
            {
                if (!_edges.ContainsKey(index))
                {
                    return null;
                }
                return _edges[index].Select(idx => _nodes[idx]).ToArray();
            }
        }

        public bool IsCompleted()
        {
            if (!IsStarted())
            {
                return false;
            }

            return _index >= _nodes.Count;
        }

        public IFlow<IForwardResult> Forward(IFlow<IMessage> message)
        {
            if (!IsStarted() || IsCompleted()) {
                return Flow<IForwardResult>.Return(new ForwardResult(ForwardResultType.Denied));
            }

            var node = GetCurrentNode();
            if (node == null)
            {
                return Flow<IForwardResult>.Return(new ForwardResult(ForwardResultType.Denied));
            }

            return message.Select(msg => {
                var ctx = new DAGraphContext(this, node, msg);
                if (InLastNode())
                { // 节点进入有守卫，但是退出是自由的
                    _index = int.MaxValue; // 标记完成
                    _listener.OnEnd();
                    return (IForwardResult)new ForwardResult(ForwardResultType.Accept);
                }
                else
                {
                    var sucNodes = GetSuccessNodes()
                                    .Where(n => n.Guard == null || n.Guard(ctx));
                    if(prioritySelector != null)
                    {
                        sucNodes = sucNodes.OrderBy(n => prioritySelector(n));
                    }
                    var nextNode = sucNodes.FirstOrDefault();
                    if (nextNode == null)
                    {
                        return new ForwardResult(ForwardResultType.Denied);
                    }

                    _listener.OnVisitNode(node, nextNode);
                    _index = _nodes.IndexOf(nextNode);
                    return new ForwardResult(ForwardResultType.Accept);
                }

            });
     
        }

        public void AddListener(IDAGraphListener listener)
        {
            _listener.Register(listener);
        }

        public void RemoveListener(IDAGraphListener listener)
        {
            _listener.Unregister(listener);
        }

        public IMay<IForwardResult> Start()
        {
            return May<IForwardResult>.Defer(() =>
            {
                if(_nodes.Count == 0)
                {
                    _listener.OnStart();
                    _listener.OnEnd();
                    return May<IForwardResult>.Return(new ForwardResult(ForwardResultType.Accept));
                }

                if (Linear)
                {
                    var entry = _nodes.First();

                    var ctx = new DAGraphContext(this, entry, null);
                    if (entry.Guard == null || entry.Guard(ctx))
                    {
                        _listener.OnStart();
                        _index = 0;
                        _listener.OnVisitNode(null, entry);
                        return May<IForwardResult>.Return(new ForwardResult(ForwardResultType.Accept));
                    }
                    else
                    {
                        return May<IForwardResult>.Return(new ForwardResult(ForwardResultType.Denied));
                    }
                }
                else
                {
                    var entrys = _nodes
                    .Where(n => n.IsEntry)
                    .Where(n =>
                    {
                        var ctx = new DAGraphContext(this, n, null);
                        return n.Guard ==null || n.Guard(ctx);
                    });

                    if (prioritySelector != null)
                    {
                        entrys = entrys.OrderBy(prioritySelector);
                    }
                    var entry = entrys.FirstOrDefault();
                    if (entry != null)
                    {

                        _listener.OnStart();
                        _index = _nodes.IndexOf(entry);
                        _listener.OnVisitNode(null, entry);
                        return May<IForwardResult>.Return(new ForwardResult(ForwardResultType.Accept));
                    }
                    else
                    {
                        return May<IForwardResult>.Return(new ForwardResult(ForwardResultType.Denied));
                    }
                }
            });
        }

        public INode[] GetSuccessNodes(INode node)
        {
            var index = _nodes.IndexOf(node);
            return GetSuccessNodes(index);
        }
    }
}
