namespace QS.DAG.Config.Model
{
    internal class DAGraphConfig
    {
        public DAGraphConfiguration GraphConfiguration { get; }
        public DAGraphStructureData GraphStructure { get; }

        public DAGraphConfig(DAGraphConfiguration graphConfiguration, DAGraphStructureData graphModel)
        {
            GraphConfiguration = graphConfiguration;
            GraphStructure = graphModel;
        }


    }
}
