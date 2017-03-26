using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IdeallyConnected.Library.DataStructures
{
    public class BinaryTreeNode<T> : Node<T>
    {
        public BinaryTreeNode() : base() { }
        public BinaryTreeNode(T data) : base(data, null) { }
        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            base.Value = data;
            NodeList<T> children = new NodeList<T>(2);
            children[0] = left;
            children[1] = right;
            base.Neighbors = children;
        }

        public BinaryTreeNode<T> Left
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                return (BinaryTreeNode<T>)base.Neighbors[0];
            }
            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(2);
                base.Neighbors[0] = value;
            }
        }

        public BinaryTreeNode<T> Right
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                return (BinaryTreeNode<T>)base.Neighbors[1];
            }
            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(2);
                base.Neighbors[1] = value;
            }
        }
    }

    public class BinaryTree<T>
    {
        public BinaryTree() { _root = null; }
        private BinaryTreeNode<T> _root = null;
        public BinaryTreeNode<T> Root
        {
            get
            {
                return _root;
            }
            set
            {
                _root = value;
            }
        }

        public virtual void Clear()
        {
            _root = null;
        }
    }
}
