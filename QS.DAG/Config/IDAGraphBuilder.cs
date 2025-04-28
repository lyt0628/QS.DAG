using QS.DAG.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace QS.DAG.Config
{
    /// <summary>
    /// 创建 DAGraph 的建造者接口
    /// </summary>
    internal interface IDAGraphBuilder
    {
        IDAGraph Build();
        IDAGraphFactory BuildFactory();
        IDAGraphModelConfigurer WithModel();
        IDAGraphConfigurationConfigurer WithConfiguration();
    }
}
