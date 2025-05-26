namespace QS.DAG.Core
{
    internal class DAGraphContext : IDAGraphContext
    {

        public IDAGraph Graph { get; }

        public DAGraphContext(IDAGraph graph, INode node, IMessage message)
        {
            Graph = graph;
            Node = node;
            Message = message;
        }

        public INode Node { get; }

        public IMessage Message { get; }
    }
}
