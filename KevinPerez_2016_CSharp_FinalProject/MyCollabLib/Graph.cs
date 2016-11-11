using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Gaming.Input.Custom;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media.Animation;
/*
    Notes
If the BFS algorithm uses a Stack instead of a Queue, the algorithm will traverse a vertice
and all of its descendents in the graph before traversing the vertice's siblings. Also, if a stack
is used, than the vertice we get from the Stack will be the last one we put on. Now instead of putting
it on the Stack and then removing it, we can continue the search with that vertice by using recursion.

    During the BF and DF surveys, parent info is collected during the course of the algorithm and stored
    in the List parent[].
    After Search(s, (V(s, T(s)) is a tree with root p. If G is a digraph, the edges of T(p) are 
    directed away from p. 
    V(s) = x such that x is reachable from s.
    T(s) = (parent(x), x) such that x != s pand x is reachable from s; (parent(x),x) is a directed edge, p->x.
    (V(s),T(s)) can be called the "search tree" starting at s.

    After Search(), (V,F), aka "search forest" is a forest whose trees are all of the search trees generated 
    by the survey starting at s. I.e. F = Union(T(s), on vertices s)


    UGraph<T> is a graph class implemented with an adjacency list.
		
		11/9/16
		This still needs to be tested.
*/
namespace MyCollabLib
{
    public class Node
    {
        public int Distance { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Weights { get; set; }
        public List<Node> AdjacencyList { get; set; }

        public Node(int distance, int id, string name)
        {
            Distance = distance;
            Id = id;
            Name = name;
            Weights = new List<int>();
            AdjacencyList = new List<Node>();
        }
    }

    public class Vertex
    {
        private readonly Node _vertexNode;
        private readonly List<int> _weights;
        private readonly List<Node> _edges;
        // accessors
        public Node VertexNode => _vertexNode;
        public List<int> Weights => _weights;
        public List<Node> Edges => _edges;

        public Vertex(Node vNode, IReadOnlyList<int> weights, IReadOnlyList<Node> edges)
        {
            _vertexNode = vNode;
            _weights = new List<int>();
            _edges = new List<Node>(edges.Count);
            // Deep copy
            _weights.AddRange(weights);
            _edges.AddRange(edges);
        }
    }

    public class PriorityQueue
    {
        public int HeapSize { get; private set; }
        private List<Node> _nodeList;

        public int Size => HeapSize;
        public List<Node> NodeList => _nodeList;

        public PriorityQueue(IReadOnlyList<Node> nlist)
        {
            HeapSize = nlist.Count;
            _nodeList.AddRange(nlist);
            _nodeList = new List<Node>(nlist);
        }

        public void Exchange(int i, int j)
        {
            Node tempNode = _nodeList[i];
            _nodeList[i] = _nodeList[j];
            _nodeList[j] = tempNode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        public void Heapify(int i)
        {
            int left = 2*i + 1;
            int right = 2*i + 2;
            int largest = -1;

            if (left < HeapSize && _nodeList[left].Distance > _nodeList[i].Distance)
                largest = left;
            else
                largest = i;
            if (right < HeapSize && _nodeList[right].Distance > _nodeList[largest].Distance)
                largest = right;
            if (largest != i)
            {
                Exchange(i, largest);
                Heapify(largest);
            }
        }

        public void BuildHeap()
        {
            for (int i = HeapSize/2; i >= 0; --i)
                Heapify(i);
        }

        public int HeapSearch(Node node)
        {
            for (int i = 0; i < HeapSize; ++i)
            {
                Node tempNode = _nodeList[i];
                if (node.Id == tempNode.Id)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Return null if specified element is out of range.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Node ElementAt(int i)
        {
            try
            {
                return _nodeList[i];

            }
            catch (ArgumentOutOfRangeException e)
            {
                return null; 
            }
        }

        public void HeapSort()
        {
            int originalheapsize = HeapSize;
            BuildHeap();
            for (int i = HeapSize - 1; i >= 1; --i)
            {
                Exchange(0, i);
                --HeapSize;
                Heapify(0);
            }
            HeapSize = originalheapsize;
        }

        public Node ExtractMin()
        {
            if (HeapSize < 1)
                return null;
            HeapSort();
            Exchange(0, HeapSize - 1);
            --HeapSize;
            return _nodeList[HeapSize];
        }
    }

    public class Graph
    {
        private List<int> _attribute;
        private List<int> _attributeCount;
        private List<Vertex> _vertex;

        public List<int> Attribute
        {
            get { return _attribute; }
            set { _attribute = value; }
        }

        public List<int> AttributeCount
        {
            get { return _attributeCount; }
            set { _attributeCount = value; }
        }

        public List<Vertex> Vertex
        {
            get { return _vertex; }
            set { _vertex = value; }
        }

        public Graph()
        {
            _attribute = new List<int>();
            _attributeCount = new List<int>();
            _vertex = new List<Vertex>();
        }

        public Graph(Graph copy)
        {
            _attribute = new List<int>(copy._attribute);
            _attributeCount = new List<int>(copy._attributeCount);
            _vertex = new List<Vertex>(copy._vertex);
        }
    }

    // Undirected graph
    public class UGraph<V> 
    {
        #region
        protected List< LinkedList<V> > _adjList;  
        #endregion

        public UGraph()
        {
            _adjList = new List< LinkedList<V> >();
        }

        public UGraph(V v)
        {
            _adjList = new List<LinkedList<V>>(Convert.ToInt32(v));
        }
        
        public void SetVertexSize(V v)
        {
            _adjList.Capacity = Convert.ToInt32(v);
        }

        public void PushVertex()
        {
            _adjList.Add(new LinkedList<V>());
        }

        public void AddEdge(V from, V to)
        {
            _adjList[Convert.ToInt32(from)].AddLast(to);
            _adjList[Convert.ToInt32(to)].AddLast(from);
        }

        public bool HasEdge(int from, int to)
        {
            foreach(var j in _adjList[from])
            {
                if (Convert.ToInt32(j) == to)
                    return true;
            }
            return false;
        }

        public int VertexSize()
        {
            return _adjList.Count;
        }

        public int EdgeSize()
        {
            int esize = 0;
            for (int i = 0; i < _adjList.Count; ++i)
                esize += _adjList[i].Count;
            return esize / 2;
        }

        public int OutDegree(V v)
        {
            return _adjList[Convert.ToInt32(v)].Count;
        }

        public int InDegree(V v)
        {
            return OutDegree(v);
        }
        
        public void SortStar(V x)
        {
            int index = Convert.ToInt32(x);
            var orderedList = _adjList[Convert.ToInt32(x)].ToList().OrderBy(n => n);
            _adjList[index] = new LinkedList<V>(orderedList);
        } 

        public LinkedList<V>.Enumerator Begin(V x)
        {
            return _adjList[Convert.ToInt32(x)].GetEnumerator();        
        }

        public LinkedList<V>.Enumerator End(V x)
        {
            return _adjList[Convert.ToInt32(x)].GetEnumerator();
        }

        public void Clear()
        {
            for(int i = 0; i < VertexSize(); ++i)
            {
                _adjList[i].Clear();
            }
            _adjList.Clear();
        }

        public void Dump()
        {

        }
    }

    // Directed Graph
    public class OGraph<T>
    {
        #region variables
        IList<T> AdjacencyItr;
        protected List<LinkedList<T>> container;
        private Type _vertex = typeof(T);
        #endregion

        public Type Vertex
        {
            get
            {
                return _vertex;
            }
        }
        

        
        public OGraph()
        {
            container = new List < LinkedList<T> >();
        }


        public ImmutableList<T> Begin(T v)
        {
            //var t = container[0].GetEnumerator(); //.First;
            return container[0].ToImmutableList();
        }

    }

    internal sealed class Deque<T> //: IList<T>, IList
    {
        public int Capacity { get; set; }
        
        public Deque()
        {

        }

        public Deque(int capacity)
        {

        }

        public Deque(IEnumerable<T> collection)
        {

        }

        public void PushBack(T value)
        {

        }

        public void PushFront(T value)
        {

        }

       
    } // class Deque

    /// <summary>
    /// This class contains a reference to a graph object on which the survey is performed,
    /// private data used in the algorithm control, and public variables to house three results
    /// of the survey (distance, parent, color) for each vertex in the graph. 
    /// distance[x] - the number of edges travelled to get from v to x
    /// parent[x] - the vertex from which x was discovered
    /// color[x] - either black of white depending on whether x was reachable from v
    /// 
    /// </summary>
    class BFSurvey
    {
        #region
        public List<int> distance;           // distance of element i from the origin
        public List<Vertex> parent;          // for BFS tree
        public List<Windows.UI.Color> color; // bookkeeping
        private OGraph<Type> _g;
        private List<bool> _visited;
        private Deque<Vertex> conQ_; // control queue
        #endregion

        public BFSurvey(OGraph<Type> g)
        {
            distance = new List<int>();
            //parent(g.vSize, null)
        }

        /*
            This repeatedly calls Search(v) to ensure that the survey considers the entire
            graph. It will continue until every vertice is found.

            Runtime: O(|V| + |E|) or THETA(|V| + |E|)
         */
        public void Search()
        {
            /*
                Reset();
                foreach vertex v of g_
                    if color[v] == white, Search(v)
                
            */
        }

        public void Reset()
        {
            /*
                foreach vertex v of g_
                    _visited[v] = 0;
                    _distance[v] = g.eSize + 1;
                    parent[v] = null;
                    color[n] = white;
            */
        }
        /*
            The visited flags and parent info are not automatically unset at the start
            of the search so that this method can be called more than once to continue the
            survey in any parts of the graph that were not reachable from v.
            After a call to this function, Search(s), by the Breadth-First Tree Theorem:
                (1) For each reachable vertex x in V, distance[x] is the shortest-path distance from s to x;
                (2) and the breadth-first tree contains a shortest path from s to x.
            Runtime: O(|V| + |E|)
        */
        /*
        public void Search(Vertex v)
        {
            conQ_.PushBack(v);
            _visited[v] = true;
            distance[v] = 0;
            color[v] = Windows.UI.Colors.MediumSeaGreen;
            while(!conQ_.Empty())
            {
                f = conQ_.Front();
                if(n = /*unvisited adjacent from f in g_*/
/*                {
                    conQ_.PushBack(n);
                    visited_[n] = true;
                    distance[n] = distance[f] + 1;
                    parent[n] = f;
                    color[n] = Windows.UI.Colors.MediumSeaGreen;
                }
                else
                {
                    conQ_.PopFront();
                    color[f] = Windows.UI.Colors.SeaGreen;
                }
            }

        }
        */


    }


    /*
        Parenthesis Theorem: Assume G is a directed/ undirected graph and Search() has been run on G,
        Then for two vertices x and y, exactly one of the following three conditions hold:
        (1) The time intervals [t_d(x), t_f(x)] and [t_d(y), t_f(y)] are disjoint, and x and y belong to
            different trees in the DFS forest.
        (2) [t_d(x), t_f(x)] is a subset of t_d(y), t_f(y)], and x is a DESCENDENT of y in the forest.
        (3) [t_d(x), t_f(x)] is a superset of t_d(y), t_f(y)], and x is an ANCESTOR of y in the forest.

    */
    class DFSurvey
    {

    }

}
