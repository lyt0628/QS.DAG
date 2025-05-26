using QS.DAG.Core;

namespace QS.DAG.Config
{
    /// <summary>
    /// 创建 DAGraph 的建造者接口
    /// </summary>
    internal interface IDAGraphBuilder
    {
        IDAGraph GetDAGraph();
        IDAGraphFactory GetDAGraphFactory();
        IDAGraphModelConfigurer ConfigStructure();
        IDAGraphConfigurationConfigurer ConfigConfiguration();
    }
}
