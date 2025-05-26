using QS.DAG.Config.Model;
using QS.HierachyConfigurer;

namespace QS.DAG.Config
{
    internal class DAGraphConfigBuilder
                        : ParentBuilderConfigurerBase<DAGraphConfig,
            DAGraphConfigBuilder,
            IDAGraphConfigConfigurer>, IDAGraphConfigConfigurer
    {
        private DAGraphConfigurationBuilder _configurationBuilder;
        private DAGraphStructureDataBuilder _modelBuilder;

        public IDAGraphConfigConfigurer Config(DAGraphStructureDataBuilder modelConfigurer)
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
