namespace QS.DAG.Core
{
    /// <summary>
    /// 节点的上下文
    /// </summary>
    public interface IDAGraphContext
    {
        IDAGraph Graph { get; }

        /// <summary>
        /// 获取当前关注的节点
        /// </summary>
        /// <returns></returns>
        INode Node { get; }

        /// <summary>
        /// 如果当前阶段由事件驱动，否则 null
        /// </summary>
        IMessage Message { get; }
    }
}
