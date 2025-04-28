using QS.DAG.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace QS.DAG.Config
{
    public class DAGraphBuilder : IDAGraphBuilder
    {
        private DAGraphConfigurationBuilder _configurationBuilder;
        private DAGraphModelBuilder _modelBuilder;

        public IDAGraph Build()
        {
            return BuildFactory().GetGraph();
        }

        public IDAGraphFactory BuildFactory()
        {
            var configBuilder = new DAGraphConfigBuilder();
            configBuilder.Config(_modelBuilder);
            configBuilder.Config(_configurationBuilder);
            return new DAGraphFactory(configBuilder);
        }

        public IDAGraphConfigurationConfigurer WithConfiguration()
        {
            _configurationBuilder = new DAGraphConfigurationBuilder();
            return _configurationBuilder;
        }

        public IDAGraphModelConfigurer WithModel()
        {
            _modelBuilder = new DAGraphModelBuilder();
            return _modelBuilder;
        }
    }
}
