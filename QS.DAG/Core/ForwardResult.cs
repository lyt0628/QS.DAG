namespace QS.DAG.Core
{
    internal class ForwardResult : IForwardResult
    {
        public ForwardResultType Type { get; }

        public ForwardResult(ForwardResultType type, IMessage message = null)
        {
            Type = type;
            Message = message;
        }

        public IMessage Message { get; }
    }
}
