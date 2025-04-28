using System;
using System.Collections.Generic;
using System.Text;

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
