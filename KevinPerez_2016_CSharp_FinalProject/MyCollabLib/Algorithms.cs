using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollabLib {
    public class Algorithms 
    {
        public List<int> Dijkstra(ref int[] pi, ref List<Node> G, int s)
        {
            InitializeSingleSource(ref pi, ref G, s);
            List<int> S = new List<int>();
            PriorityQueue Q = new PriorityQueue(G);
            Q.BuildHeap();

            while (Q.HeapSize != 0)
            {
                Node u = Q.ExtractMin();
                S.Add(u.Id);

                for (int i = 0; i < u.AdjacencyList.Count; ++i)
                {
                    Node v = u.AdjacencyList[i];
                    int w = u.Weights[i];
                    Relax(ref pi, u, ref v, w);
                }
            }
            return S;
        }
        /// <summary>
        /// Initialize the array denoting the distance between the nodes
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="nodeList"></param>
        /// <param name="s"></param>
        private void InitializeSingleSource(ref int[] pi, ref List<Node> nodeList, int s)
        {
            pi = new int[nodeList.Count];
            for (int i = 0; i < pi.Length; ++i)
                pi[i] = -1;

            nodeList[s].Distance = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="w"></param>
        private void Relax(ref int[] pi, Node u, ref Node v, int w)
        {
            if (v.Distance > u.Distance + w)
            {
                v.Distance = u.Distance + w;
                pi[v.Id] = u.Id;
            }
        }
    }
}
