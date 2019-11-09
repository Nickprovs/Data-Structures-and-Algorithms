using System;
using System.Collections.Generic;
using System.Text;

namespace LinearLibrary.LinkedListSingle
{
    internal class NodeSingle
    {
        internal int Value;
        internal NodeSingle Next;

        internal NodeSingle(int value)
        {
            this.Value = value;
            this.Next = null;
        }
    }
}
