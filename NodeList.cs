using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    internal class NodeList<T>
    {
        public T Value { get; set; }
        public NodeList<T>? Next { get; set; }

        public NodeList(T value)
        {
            this.Value = value;
            this.Next = null;
        }
    }
}
