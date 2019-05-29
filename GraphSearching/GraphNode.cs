using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSearching
{
     /// <summary>
     /// A graph node
     /// </summary>
     /// <typeparam name="T">type of value stored in node</typeparam>
    class GraphNode<T>
    {
        #region Fields

        T value;
        BallColor ballColor;
        List<GraphNode<T>> neighbors;
        List<int> costs;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">value for the node</param>
        public GraphNode(T value)
        {
            this.value = value;
            neighbors = new List<GraphNode<T>>();
            costs = new List<int>();
            ballColor = BallColor.empty;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the value stored in the node
        /// </summary>
        public T Value
        {
            get { return value; }
        }

        /// <summary>
        /// Gets a read-only list of the neighbors of the node
        /// </summary>
        public IList<GraphNode<T>> Neighbors
        {
            get { return neighbors.AsReadOnly(); }
        }

        public IList<int> Costss {
            get { return costs.AsReadOnly(); }
        }

        public BallColor BallColor {
            get => ballColor;
            set => ballColor = value;
        }

        #endregion

        #region Methods

        public int GetEdgeCost(GraphNode<T> node) {
            if (!neighbors.Contains(node)) {
                throw new InvalidOperationException("Trying to retreive cost-edge of non existing node ");
            } else {
                int index = neighbors.IndexOf(node);
                return costs[index];
            }
            //return -1;
        }

        /// <summary>
        /// Adds the given node as a neighbor for this node
        /// </summary>
        /// <param name="neighbor">neighbor to add</param>
        /// <returns>true if the neighbor was added, false otherwise</returns>
        public bool AddNeighbor(GraphNode<T> neighbor, int cost)
        {
            // don't add duplicate nodes
            if (neighbors.Contains(neighbor))
            {
                return false;
            }
            else
            {
                neighbors.Add(neighbor);
                costs.Add(cost);
                return true;
            }
        }

        /// <summary>
        /// Removes the given node as a neighbor for this node
        /// </summary>
        /// <param name="neighbor">neighbor to remove</param>
        /// <returns>true if the neighbor was removed, false otherwise</returns>
        public bool RemoveNeighbor(GraphNode<T> neighbor) {
            // only remove neighbors in list
            if (!Neighbors.Contains(neighbor)) {
                return false;
            } else {
                int index = neighbors.IndexOf(neighbor);
                costs.RemoveAt(index);
                neighbors.Remove(neighbor);
                return true;
            }
        }

        /// <summary>
        /// Removes all the neighbors for the node
        /// </summary>
        /// <returns>true if the neighbors were removed, false otherwise</returns>
        public bool RemoveAllNeighbors()
        {
            for (int i = neighbors.Count - 1; i >= 0; i--)
            {
                neighbors.RemoveAt(i); // ????
                //costs.RemoveAt(i);
            }
            costs.Clear();
            return true;
        }

        /// <summary>
        /// Converts the node to a string
        /// </summary>
        /// <returns>the string</returns>
        public override string ToString()
        {
            StringBuilder nodeString = new StringBuilder();
            nodeString.Append("[Node Value: " + value +
                " Neighbors: ");
            for (int i = 0; i < neighbors.Count; i++)
            {
                nodeString.Append(neighbors[i].Value + " (" + costs[i] + "), ");
            }
            nodeString.Append("]");
            return nodeString.ToString();
        }

        #endregion
    }
}
