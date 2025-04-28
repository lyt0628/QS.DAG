using System;
using System.Collections.Generic;
using System.Text;

namespace QS.DAG.Config
{
    internal interface IDAGraphConfigConfigurer
    {
        IDAGraphConfigConfigurer Config(DAGraphModelBuilder modelConfigurer);

        IDAGraphConfigConfigurer Config(DAGraphConfigurationBuilder configurationConfigurer);
    }

}
