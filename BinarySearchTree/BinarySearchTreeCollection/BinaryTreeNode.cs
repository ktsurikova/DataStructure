using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeCollection
{
    internal class BinaryTreeNode<T> //where T : IComparer<T>
    {
 
        public T Value { get; set; }

        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode() { }
        public BinaryTreeNode(T data) : this(data, null, null) { }
        public BinaryTreeNode(T data, BinaryTreeNode<T> otherLeft, BinaryTreeNode<T> otherRight)
        {
            Value = data;
            Left = otherLeft;
            Right = otherRight;
        }



    }
}
