namespace QS.DAG.Config
{
    /// <summary>
    /// 节点配置
    /// </summary>
    public interface IDAGraphModelConfigurer
    {
        //IList<>
        INodeConfigurer WithNode();
    }
}
