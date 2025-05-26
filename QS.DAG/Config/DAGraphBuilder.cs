using QS.DAG.Core;

namespace QS.DAG.Config
{
    public class DAGraphBuilder : IDAGraphBuilder
    {
        private DAGraphConfigurationBuilder _configurationBuilder;
        private DAGraphStructureDataBuilder _structureDataBuilder;

        public IDAGraph GetDAGraph()
        {
            return GetDAGraphFactory().GetDAGraph();
        }

        public IDAGraphFactory GetDAGraphFactory()
        {
            var configBuilder = new DAGraphConfigBuilder();
            configBuilder.Config(_structureDataBuilder);
            configBuilder.Config(_configurationBuilder);
            return new DAGraphFactory(configBuilder);
        }

        public IDAGraphConfigurationConfigurer ConfigConfiguration()
        {
            _configurationBuilder = new DAGraphConfigurationBuilder();
            return _configurationBuilder;
        }

        public IDAGraphModelConfigurer ConfigStructure()
        {
            _structureDataBuilder = new DAGraphStructureDataBuilder();
            return _structureDataBuilder;
        }
    }
}
