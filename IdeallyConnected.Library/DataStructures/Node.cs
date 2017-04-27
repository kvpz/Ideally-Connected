using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IdeallyConnected.Library.DataStructures
{
    public class Node<T>
    {
        public Node() { }
        public Node(T data) : this(data, null) { }
        public Node(T data, NodeList<T> neighbors)
        {
            this._data = data;
            this._neighbors = neighbors;
        }

        private T _data;
        private NodeList<T> _neighbors = null;
        public T Value
        {
            get { return _data; }
            set { _data = value; }
        }
        public NodeList<T> Neighbors
        {
            get { return _neighbors; }
            set { _neighbors = value; }
        }
    }

    public class NodeList<T> : Collection<Node<T>>
    {
        public NodeList() : base() { }
        public NodeList(int initialSize)
        {
            for (int i = 0; i < initialSize; ++i)
            {
                base.Items.Add(default(Node<T>));
            }
        }

        public Node<T> FindByValue(T value)
        {
            foreach (Node<T> node in Items)
            {
                if (node.Value.Equals(value))
                    return node;
            }

            return null;
        }
    }
}
