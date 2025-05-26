namespace QS.DAG.Core
{
    public class Message : IMessage
    {
        public MessageHeader Header { get; }

        public Message()
        {
            Header = new MessageHeader();
        }

        public Message(MessageHeader header)
        {
            Header = header;
        }
    }
}
