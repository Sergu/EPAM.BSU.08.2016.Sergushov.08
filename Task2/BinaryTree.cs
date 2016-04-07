using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public enum Side
    {
        Left,
        Right
    }
    public class BinaryTree<T> 
    {
        public T Data { get; private set; }
        private int hash;
        private BinaryTree<T> Left {get;set;}
        private BinaryTree<T> Right { get; set; }
        private BinaryTree<T> Parent { get; set; }

        public BinaryTree(T item)
        {
            this.Data = item;
            hash = Data.GetHashCode();
        }
        public BinaryTree() { }

        public void Remove(T data)
        {
            Remove(data,new DefaultComparator<T>());
        }
        public void Remove(T data,IComparer<T> comparator)
        {
            var removeNode = Find(data,comparator);
            if (removeNode != null)
            {
                Remove(removeNode,comparator);
            }
        }
        public void Remove(BinaryTree<T> node,IComparer<T> comparator)
        {
            if (node == null) return;

            var me = MeForParent(node);

            if (node.Left == null && node.Right == null)
            {
                if (me == Side.Left)
                {
                    node.Parent.Left = null;
                }
                else
                {
                    node.Parent.Right = null;
                }
                return;
            }

            if (node.Left == null)
            {
                if (me == Side.Left)
                {
                    node.Parent.Left = node.Right;
                }
                else
                {
                    node.Parent.Right = node.Right;
                }

                node.Right.Parent = node.Parent;
                return;
            }

            if (node.Right == null)
            {
                if (me == Side.Left)
                {
                    node.Parent.Left = node.Left;
                }
                else
                {
                    node.Parent.Right = node.Left;
                }

                node.Left.Parent = node.Parent;
                return;
            }

            if (me == Side.Left)
            {
                node.Parent.Left = node.Right;
            }
            if (me == Side.Right)
            {
                node.Parent.Right = node.Right;
            }
            if (me == null)
            {
                var bufLeft = node.Left;
                var bufRightLeft = node.Right.Left;
                var bufRightRight = node.Right.Right;
                node.Data = node.Right.Data;
                node.Right = bufRightRight;
                node.Left = bufRightLeft;
                Insert(bufLeft, node, node,comparator);
            }
            else
            {
                node.Right.Parent = node.Parent;
                Insert(node.Left, node.Right, node.Right,comparator);
            }
        }
        public BinaryTree<T> Find(T data)
        {
            return Find(data,new DefaultComparator<T>());
        }
        public BinaryTree<T> Find(T data,IComparer<T> comparator)
        {
            if (comparator.Compare(Data,data) == 0)
                return this;
            if (comparator.Compare(Data, data) > 0)
            {
                return Find(data, Left,comparator);
            }
            return Find(data, Right, comparator);
        }
        public BinaryTree<T> Find(T data, BinaryTree<T> node)
        {
            return Find(data, node, new DefaultComparator<T>());
        }
        public BinaryTree<T> Find(T data, BinaryTree<T> node, IComparer<T> comparator)
        {
            if (node == (dynamic)default(T))
                return null;
            if (comparator.Compare(node.Data,data) == 0)
                return node;
            if (comparator.Compare(node.Data, data) > 0)
            {
                return Find(data, node.Left,comparator);
            }
            return Find(data, node.Right,comparator);
        }
        public void Insert(T data)
        {
            Insert(data,new DefaultComparator<T>());
        }
        public void Insert(T data,IComparer<T> comparator)
        {
            if((Data == (dynamic)default(T)) || (comparator.Compare(this.Data,data) == 0))
            {
                Data = data;
                return;
            }
            if(comparator.Compare(this.Data,data) > 0)
            {
                if(ReferenceEquals(Left,null))
                    this.Left = new BinaryTree<T>();
                Insert(data,Left,this,comparator);
            }
            else
            {
                if(ReferenceEquals(Right,null))
                    this.Right = new BinaryTree<T>();
                Insert(data,Right,this,comparator);
            }

        }
        public long GetElementsAmount()
        {
            return GetElementsAmount(this);
        }
        private long GetElementsAmount(BinaryTree<T> node)
        {
            long count = 1;
            if (node.Right != null)
            {
                count += GetElementsAmount(node.Right);
            }
            if (node.Left != null)
            {
                count += GetElementsAmount(node.Left);
            }
            return count;
        }

        private Side? MeForParent(BinaryTree<T> node)
        {
            if (node.Parent == null) return null;
            if (node.Parent.Left == node) return Side.Left;
            if (node.Parent.Right == node) return Side.Right;
            return null;
        }
        private void Insert(T data, BinaryTree<T> node, BinaryTree<T> parent,IComparer<T> comparator)
        {
            if ((node.Data == (dynamic)default(T)) || (comparator.Compare(node.Data,data) == 0))
            {
                node.Data = data;
                node.Parent = parent;
                return;
            }
            if (comparator.Compare(node.Data,data) > 0)
            {
                if (ReferenceEquals(node.Left,null))
                    node.Left = new BinaryTree<T>();
                Insert(data, node.Left, node,comparator);
            }
            else
            {
                if (ReferenceEquals(node.Right,null))
                    node.Right = new BinaryTree<T>();
                Insert(data, node.Right, node,comparator);
            }
        }
        private void Insert(BinaryTree<T> data, BinaryTree<T> node, BinaryTree<T> parent,IComparer<T> comparator)
        {
            if ((node.Data == (dynamic)default(T)) || (comparator.Compare(node.Data,data.Data) == 0))
                {
                    node.Data = data.Data;
                    node.Left = data.Left;
                    node.Right = data.Right;
                    node.Parent = parent;
                    return;
            }
            if (comparator.Compare(node.Data,data.Data) > 0)
            {
                if (node.Left == null)
                    node.Left = new BinaryTree<T>();
                Insert(data, node.Left, node,comparator);
            }
            else
            {
                if (node.Right == null)
                    node.Right = new BinaryTree<T>();
                Insert(data, node.Right, node,comparator);
            }
        }

    }
}
