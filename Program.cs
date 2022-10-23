using grafo_ejemplo_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo_grafo_2
{
    class EjemploGrafo1
    {
        static void Main(string[] args)
        {
            int nodo = 0;

            Graph nGraph = new Graph(7);

            nGraph.addEdge(0, 1);
            nGraph.addEdge(0, 3);
            nGraph.addEdge(1, 3);
            nGraph.addEdge(1, 4);
            nGraph.addEdge(2, 0);
            nGraph.addEdge(2, 5);
            nGraph.addEdge(3, 5);
            nGraph.addEdge(3, 2);
            nGraph.addEdge(3, 6);
            nGraph.addEdge(3, 4);
            nGraph.addEdge(4, 6);
            nGraph.addEdge(6, 5);


            nGraph.showAdjacency();

            Console.WriteLine("\n");

            nGraph.calculateIndegree();
            nGraph.showIndegree();

            Console.WriteLine("\n");

            Console.ForegroundColor = ConsoleColor.Blue;

            //ordenamiento topologico
            //do
            //{
            //    nodo = nGraph.findIndegreeZero();

            //    if (nodo != -1)
            //    {
            //        Console.Write("{0}--> ", nodo);

            //        nGraph.decrementIndegree(nodo);
            //    }
            //} while (nodo != -1);

            Console.WriteLine();


            Console.WriteLine("get first nodo");
            String data = Console.ReadLine();
            int first = Convert.ToInt32(data);


            Console.WriteLine("get final nodo");
            data = Console.ReadLine();
            int final = Convert.ToInt32(data);

            shortestPath(first, final, 7, ref nGraph);
        }


        static void shortestPath(int startNodo, int finalNodo, int totalNodos, ref Graph graph)
        {
            int distance = 0;
            int n = 0;
            int m = 0;
            string data = "";

            //0 => visit
            //1 => distance
            //2 => previous
            int[,] table = new int[totalNodos, 3];

            for(n =0; n < totalNodos; n++){
                table[n, 0] = 0;
                table[n, 1] = int.MaxValue;
                table[n, 2] = 0;

            }

            table[startNodo, 1] = 0;

            showTable(table);

            for(distance = 0; distance < totalNodos; distance++){
                for (n = 0; n < totalNodos; n++) {
                    if (table[n,0] == 0 && table[n,1] == distance){
                        table[n, 0] = 1;

                        for(m = 0; m < totalNodos; m++){
                            //validate if adjacency
                            if(graph.getAdjacency(n, m) == 1){
                                if (table[m, 1] == int.MaxValue) {
                                    table[m, 1] = distance + 1;
                                    table[m, 2] = n;
                                }
                            }
                        }
                    }
                }
            }


            showTable(table);


            //get Path.

            List<int> path = new List<int>();
            int nodo = finalNodo;
            while(nodo != startNodo){
                path.Add(nodo);
                nodo = table[nodo, 2];
            }

            path.Add(startNodo);

            path.Reverse();

            foreach(int position in path){
                Console.Write("{0} ->", position);
            }

            Console.WriteLine();
        }


        static void showTable(int[,] table)
        {
            int n = 0;

            for(n = 0; n < table.GetLength(0); n++){
                Console.WriteLine("{0}--> {1} \t{2}\t{3}", n, table[n, 0], table[n, 1], table[n, 2]);
            }

            Console.WriteLine("-------------------------");
        }
    }
}