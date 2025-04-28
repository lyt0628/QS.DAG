using QS.DAG.Config.Model;
using QS.HierachyConfigurer;
using System;
using System.Collections.Generic;
using System.Text;

namespace QS.DAG.Config
{
    internal class DAGraphConfigBuilder
                        : ParentBuilderConfigurerBase<DAGraphConfig,
            DAGraphConfigBuilder,
            IDAGraphConfigConfigurer>, IDAGraphConfigConfigurer
    {
        private DAGraphConfigurationBuilder _configurationBuilder;
        private DAGraphModelBuilder _modelBuilder;

        public IDAGraphConfigConfigurer Config(DAGraphModelBuilder modelConfigurer)
        {
            _modelBuilder = modelConfigurer;
            return this;
        }

        public IDAGraphConfigConfigurer Config(DAGraphConfigurationBuilder configurationConfigurer)
        {
            _configurationBuilder = configurationConfigurer;
            return this;
        }

        protected override DAGraphConfig DoBuild()
        {
            var configuration = _configurationBuilder.Build();
            var model = _modelBuilder.Build();

            return new DAGraphConfig(configuration, model);
        }
    }
}
