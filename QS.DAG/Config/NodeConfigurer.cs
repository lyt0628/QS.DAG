using QS.DAG.Config.Model;
using QS.DAG.Core;
using QS.HierachyConfigurer;
using System;
using System.Collections.Generic;
using System.Text;

namespace QS.DAG.Config
{
    internal class NodeConfigurer
        : ChildConfigurerBase<DAGraphModelBuilder, IDAGraphModelConfigurer>,
        INodeConfigurer
    {
        private DAGraphModelBuilder _graphNodeConfigurer;
        private readonly string _prevId;

        public NodeConfigurer(string prevId = null)
        {
            this._prevId = prevId;
        }

        private string _id;
        private Func<IDAGraphContext, bool> _guard;
        private object _userData;
        private readonly List<string> _nextIds;

        public NodeConfigurer()
        {
            this._nextIds = new List<string>();
        }

        public override void InitSelf(DAGraphModelBuilder parent)
        {
            this._graphNodeConfigurer = parent;
        }

        public override void ConfigParent(DAGraphModelBuilder parent)
        {
            if (_id == null)
            {
                _id = Guid.NewGuid().ToString();
            }

            var node = new NodeData(_id, _guard, _userData, true);


            parent.AddNode(node);
            if (_prevId != null)
            {
                
                var edge = new EdgeData(_prevId, _id);
                parent.AddEdge(edge);
            }
            if(_nextIds != null)
            {

                foreach (var nextId in _nextIds)
                {
                    var edge = new EdgeData(_id, nextId);
                    parent.AddEdge(edge);
                }
            }
        }

        public INodeConfigurer Guard(Func<IDAGraphContext, bool> guard)
        {
            this._guard = guard;
            return this;
        }

        public INodeConfigurer Id(string id)
        {
            if(_id != null)
            {
                throw new InvalidOperationException();
            }
            this._id = id;
            return this;
        }

        public INodeConfigurer UserData(object data)
        {
            this._userData = data;
            return this;
        }

        public INodeConfigurer WithNext(string targetId)
        {
            _nextIds.Add(targetId);
            return this;
        }

        public INodeConfigurer WithNext()
        {
            if(this._id == null)
            {
                throw new InvalidOperationException();
            }

            return _graphNodeConfigurer.ApplyChildConfigurer(new NodeConfigurer(_id));
        }
    }
}
