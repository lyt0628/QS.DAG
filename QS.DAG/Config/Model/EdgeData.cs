using System;
using System.Collections.Generic;
using System.Text;

namespace QS.DAG.Config.Model
{
    internal class EdgeData
    {
        public string Prev { get; }
        public string Next { get; }

        public EdgeData(string id, string refId)
        {
            Prev = id;
            Next = refId;
        }
    }
}
