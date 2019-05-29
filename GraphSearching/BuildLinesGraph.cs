using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSearching {
    class BuildLinesGraph {
        public static Graph<int> BuildGraphLin(int SIZE) { // Squere size!
            Graph<int> graph = new Graph<int>();
            int GraphSIZE = SIZE*SIZE;
            //int WIDTH = Convert.ToInt16(Math.Sqrt((double)GraphSIZE));
            int WIDTH = SIZE;
            int HEIGHT = WIDTH - 1;

            for(int i = 1; i <= GraphSIZE; ++i) {
                graph.AddNode(i);
            }
            //Console.WriteLine("Add nodes: " + graph.Count);

            for (int i = 1; i <= GraphSIZE; ++i) {
                //graph.AddNode(i);
                if ((i % WIDTH) != 0) { // Not right edge!
                    graph.AddEdge(i, i + 1, 1);
                    //Console.WriteLine("-Add edge: " + i + ", " + (i + 1));
                    if ((i / WIDTH) != HEIGHT) {
                        graph.AddEdge(i, i + WIDTH, 1);
                        //Console.WriteLine("-Add edge: " + i + ", " + (i + WIDTH));
                    }
                } else {
                    if ((i / WIDTH) != WIDTH) {
                        graph.AddEdge(i, i + WIDTH, 1);
                        //Console.WriteLine("*Add edge: " + i + ", " + (i + WIDTH));
                    }
                }
            }

            //graph.AddEdge(1, 2, 1);
            //graph.AddEdge(1, 6, 1);

            return graph;
        }

        

    }

    
}
