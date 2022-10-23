using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafo_ejemplo_2
{
    internal class Graph
    {
        int[,] adjacency;
        int[] indegree;
        int nodos;

        public Graph(int nodos)
        {
            this.nodos = nodos;

            //adyacencia
            this.adjacency = new int[nodos, nodos];

            //indegree
            this.indegree = new int[nodos];
        }

        //edge => arista
        public void addEdge(int firstNodo, int finalNodo)
        {
            this.adjacency[firstNodo, finalNodo] = 1;
        }

        public void showAdjacency()
        {
            int n = 0;
            int m = 0;

            Console.ForegroundColor = ConsoleColor.Yellow;

            for(n = 0; n < this.nodos; n++){
                Console.Write("\t{0}", n);
            }

            Console.WriteLine();

            for(n = 0; n < this.nodos; n++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(n);
                for(m = 0; m < this.nodos; m++){
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\t{0}", this.adjacency[n, m]);
                }

                Console.WriteLine();
            }
        }


        public void calculateIndegree()
        {
            int n = 0;
            int m = 0;

            for(n = 0; n < this.nodos; n++){
                for(m = 0; m < nodos; m++){
                    if (this.adjacency[m, n] == 1){
                        this.indegree[n]++;
                    }
                }
            }
        }

        public void showIndegree()
        {
            int n = 0;
            int m = 0;

            Console.ForegroundColor = ConsoleColor.White;

            for(n = 0; n < this.nodos; n++){
                Console.WriteLine("Nodo: {0}, {1}", n, this.indegree[n]);
            }
        }


        public int findIndegreeZero()
        {
            bool find = false;
            int n = 0;

            for(n = 0; n < this.nodos; n++){
                if (this.indegree[n] == 0){
                    find = true;
                    break;
                }
            }

            if (find) {
                return n;
            }
            else{
                return -1;
            }
        }

        public void decrementIndegree(int nodo)
        {
            this.indegree[nodo] = -1;

            int n = 0;

            for(n = 0; n < this.nodos; n++){
                if (this.adjacency[nodo, n] == 1){
                    this.indegree[n]--;
                }
            }
        }

        public int getAdjacency(int row, int column)
        {
            return this.adjacency[row, column];
        }


        public void addEdge(int startNodo, int finalNodo, int weight)
        {
            this.adjacency[startNodo, finalNodo] = weight;
        }
    }
}
