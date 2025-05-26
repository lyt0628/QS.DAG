namespace QS.DAG.Config
{
    internal interface IDAGraphConfigConfigurer
    {
        IDAGraphConfigConfigurer Config(DAGraphStructureDataBuilder modelConfigurer);

        IDAGraphConfigConfigurer Config(DAGraphConfigurationBuilder configurationConfigurer);
    }

}
