namespace QS.DAG.Core
{

    public interface IDAGraphListener
    {
        void OnStart();
        void OnVisitNode(INode currentNode, INode nextNode);
        void OnEnd();
    }
}
