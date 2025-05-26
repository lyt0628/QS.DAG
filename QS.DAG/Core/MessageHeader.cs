using System;
using System.Collections.Generic;
using System.Text;

namespace QS.DAG.Core
{
    public class MessageHeader : Dictionary<object, object>
    {
        public MessageHeader()
        {
        }

        public MessageHeader(IDictionary<string, object> headers) 
        {
            foreach (var pair in headers)
            {
                this[pair.Key] = pair.Value;
            }
        }
    }
}
