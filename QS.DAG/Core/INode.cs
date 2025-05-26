using System;

namespace QS.DAG.Core
{
    public interface INode
    {

        /// <summary>
        /// 当前节点ID，用来与其他节点区分
        /// </summary>
        string Id { get; }

        /// <summary>
        // 当前节点的入度是否为0
        /// </summary>
        /// <returns></returns>
        bool IsEntry { get; }

        /// <summary>
        /// 获取节点的附加数据
        /// </summary>
        object UserData { get; }

        /// <summary>
        /// 节点的守卫条件
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        Func<IDAGraphContext, bool> Guard { get; }
    }
}
