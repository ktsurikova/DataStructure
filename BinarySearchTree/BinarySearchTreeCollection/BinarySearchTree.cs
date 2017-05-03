using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeCollection
{
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        private BinaryTreeNode<T> root;
        private readonly IComparer<T> comparer;

        public BinarySearchTree(IComparer<T> otherComparer)
        {
            if (ReferenceEquals(otherComparer,null) )
                throw new BinarySearchTreeException("otherComparer is null");
            root = null;
            comparer = otherComparer;
        }

        public bool Contains(T data)
        {
            if (ReferenceEquals(data, null)) throw new BinarySearchTreeException("data is null");
            BinaryTreeNode<T> current = root;
            int result;
            while (current != null)
            {
                result = comparer.Compare(current.Value, data);
                if (result == 0)
                    return true;
                else if (result > 0)
                    current = current.Left;
                else if (result < 0)
                    current = current.Right;
            }

            return false;
        }

        #region Add
        public virtual void Add(T data)
        {
            if (ReferenceEquals(data,null)) throw new BinarySearchTreeException("data is null");

            BinaryTreeNode<T> n = new BinaryTreeNode<T>(data);
            int result;

            BinaryTreeNode<T> current = root, parent = null;
            while (current != null)
            {
                result = comparer.Compare(current.Value, data);
                if (result == 0)
                    return;
                else if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
            }
            Count++;
            if (parent == null)
                root = n;
            else
            {
                result = comparer.Compare(parent.Value, data);
                if (result > 0)
                    parent.Left = n;
                else
                    parent.Right = n;
            }
        } 
        #endregion

        #region Remove
        public bool Remove(T data)
        {
            if (ReferenceEquals(data,null))
                throw new BinarySearchTreeException("data is null");

            // first make sure there exist some items in this tree
            if (root == null)
                return false;       // no items to remove

            // Now, try to find data in the tree
            BinaryTreeNode<T> current = root, parent = null;
            int result = comparer.Compare(current.Value, data);
            while (result != 0)
            {
                if (result > 0)
                {
                    // current.Value > data, if data exists it's in the left subtree
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    // current.Value < data, if data exists it's in the right subtree
                    parent = current;
                    current = current.Right;
                }

                // If current == null, then we didn't find the item to remove
                if (current == null)
                    return false;
                else
                    result = comparer.Compare(current.Value, data);
            }

            // At this point, we've found the node to remove
            Count--;

            // We now need to "rethread" the tree
            // CASE 1: If current has no right child, then current's left child becomes
            //         the node pointed to by the parent
            if (current.Right == null)
            {
                if (parent == null)
                    root = current.Left;
                else
                {
                    result = comparer.Compare(parent.Value, current.Value);
                    if (result > 0)
                        // parent.Value > current.Value, so make current's left child a left child of parent
                        parent.Left = current.Left;
                    else if (result < 0)
                        // parent.Value < current.Value, so make current's left child a right child of parent
                        parent.Right = current.Left;
                }
            }
            // CASE 2: If current's right child has no left child, then current's right child
            //         replaces current in the tree
            else if (current.Right.Left == null)
            {
                if (parent == null)
                    root = current.Right;
                else
                {
                    result = comparer.Compare(parent.Value, current.Value);
                    if (result > 0)
                        // parent.Value > current.Value, so make current's right child a left child of parent
                        parent.Left = current.Right;
                    else if (result < 0)
                        // parent.Value < current.Value, so make current's right child a right child of parent
                        parent.Right = current.Right;
                }
            }
            // CASE 3: If current's right child has a left child, replace current with current's
            //          right child's left-most descendent
            else
            {
                // We first need to find the right node's left-most child
                BinaryTreeNode<T> leftmost = current.Right.Left, lmParent = current.Right;
                while (leftmost.Left != null)
                {
                    lmParent = leftmost;
                    leftmost = leftmost.Left;
                }

                // the parent's left subtree becomes the leftmost's right subtree
                lmParent.Left = leftmost.Right;

                // assign leftmost's left and right to current's left and right children
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if (parent == null)
                    root = leftmost;
                else
                {
                    result = comparer.Compare(parent.Value, current.Value);
                    if (result > 0)
                        // parent.Value > current.Value, so make leftmost a left child of parent
                        parent.Left = leftmost;
                    else if (result < 0)
                        // parent.Value < current.Value, so make leftmost a right child of parent
                        parent.Right = leftmost;
                }
            }

            return true;
        } 
        #endregion

        public void Clear() => root = null;

        public int Count { get; private set; }


        #region Traversal
        public IEnumerable<T> InOrder
        {
            get
            {
                var stack = new Stack<BinaryTreeNode<T>>();
                BinaryTreeNode<T> temp = root;
                while (stack.Count != 0 || temp != null)
                {
                    if (temp != null)
                    {
                        stack.Push(temp);
                        temp = temp.Left;
                    }
                    else
                    {
                        temp = stack.Pop();
                        yield return temp.Value;
                        temp = temp.Right;
                    }
                }
            }
        }

        public IEnumerable<T> PreOrder
        {
            get
            {
                var stack = new Stack<BinaryTreeNode<T>>();
                stack.Push(root);
                while (true)
                {
                    if (stack.Count == 0) break;

                    BinaryTreeNode<T> temp = stack.Pop();
                    yield return temp.Value;

                    if (temp.Right != null)
                    {
                        stack.Push(temp.Right);
                    }

                    if (temp.Left != null)
                    {
                        stack.Push(temp.Left);
                    }
                }
            }
        }

        public IEnumerable<T> PostOrder
        {
            get
            {
                var list = new List<T>();
                RecursionPostOrder(root, list);
                foreach (var item in list)
                {
                    yield return item;
                }
            }
        }

        private static void RecursionPostOrder(BinaryTreeNode<T> node, List<T> list)
        {
            if (node == null) return;
            if (node.Left != null)
                RecursionPostOrder(node.Left, list);
            if (node.Right != null)
                RecursionPostOrder(node.Right, list);
            list.Add(node.Value);
        }

        #endregion

        public IEnumerator<T> GetEnumerator()
        {
            return InOrder.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return InOrder.GetEnumerator();
        }

        public void CopyTo(T[] array, int index, TraversalMethods method)
        {
            if (ReferenceEquals(array, null)) throw new BinarySearchTreeException("array is null");
            if (index < 0) throw new BinarySearchTreeException("index is less than 0");

            List<T> list = null;
            if (method == TraversalMethods.InOrder)
            {
                list = new List<T>(InOrder);   
            }
            if (method == TraversalMethods.PreOrder)
            {
                list = new List<T>(PreOrder);
                
            }
            if (method == TraversalMethods.PostOrder)
            {
                list = new List<T>(PostOrder);
            }
            for (int i = 0; i < Count; i++)
            {
                if (index + i >= array.Length) break;
                array[index + i] = list[i];
            }
        }

    }
}
