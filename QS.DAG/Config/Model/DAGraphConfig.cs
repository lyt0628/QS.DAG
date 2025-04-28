using System;
using System.Collections.Generic;
using System.Text;

namespace QS.DAG.Config.Model
{
    internal class DAGraphConfig
    {
        public DAGraphConfiguration GraphConfiguration { get; }
        public DAGraphModel GraphModel { get; }

        public DAGraphConfig(DAGraphConfiguration graphConfiguration, DAGraphModel graphModel)
        {
            GraphConfiguration = graphConfiguration;
            GraphModel = graphModel;
        }


    }
}
