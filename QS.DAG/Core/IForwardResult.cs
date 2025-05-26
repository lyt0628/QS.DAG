namespace QS.DAG.Core
{
    public interface IForwardResult
    {
        ForwardResultType Type { get; }
        IMessage Message { get; }
    }
}
