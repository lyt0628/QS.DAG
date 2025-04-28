using System;
using System.Collections.Generic;
using System.Text;

namespace QS.DAG.Core
{
    public interface IForwardResult
    {
        ForwardResultType Type { get; }
        IMessage Message { get; }
    }
}
