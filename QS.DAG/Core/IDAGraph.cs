using QS.Reactive;
using System;
using System.Collections.Generic;
using System.Text;

namespace QS.DAG.Core
{
    /// <summary>
    /// 面向数据迭代的有向无环图
    /// </summary>
    public interface IDAGraph
    {
        string Id { get; }
        IFlow<IForwardResult> Forward(IFlow<IMessage> message);
        /// <summary>
        /// 获取当前节点
        /// </summary>
        /// <returns></returns>
        INode GetCurrentNode();
        /// <summary>
        /// 获取当前节点的后继节点
        /// </summary>
        /// <returns></returns>
        INode[] GetSuccessNodes();
        /// <summary>
        /// 获取指定节点的后继节点
        /// </summary>
        INode[] GetSuccessNodes(INode node);
        IMay<IForwardResult> Start();
        bool IsStarted();
        bool IsCompleted();
        void AddListener(IDAGraphListener listener);
        void RemoveListener(IDAGraphListener listener);
    }

}
