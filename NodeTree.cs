using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    internal class NodeTree<T>
    {
        public T Value { get; set; }
        public NodeTree<T>? Parent { get; set; }
        public NodeTree<T>? Left { get; set; }
        public NodeTree<T>? Right { get; set; }

        public NodeTree(T value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
            this.Parent = null;
        }
    }
}
