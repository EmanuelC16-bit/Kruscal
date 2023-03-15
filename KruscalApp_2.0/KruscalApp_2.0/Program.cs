using System;
using Gtk;

namespace KruscalApp_2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();
            using System;

// Definimos una estructura para representar una arista en el grafo
        public struct Edge
        {
            public int src, dest, weight;
        };

        // Función para comparar aristas según su peso, para usar en la clasificación por pesos
        public static bool CompareEdges(Edge a, Edge b)
        {
            return a.weight < b.weight;
        }

        // Función para encontrar el subconjunto de un elemento 'i' en el arreglo de subconjuntos
        public static int FindSubset(int[] parent, int i)
        {
            if (parent[i] == -1)
                return i;
            return FindSubset(parent, parent[i]);
        }

        // Función para unir dos subconjuntos en uno solo
        public static void UnionSubsets(int[] parent, int x, int y)
        {
            int xset = FindSubset(parent, x);
            int yset = FindSubset(parent, y);
            parent[xset] = yset;
        }

        // Función principal que construye y devuelve el árbol de expansión mínima usando el algoritmo de Kruskal
        public static void KruskalMST(Edge[] edges, int V, int E)
        {
            // Ordenamos las aristas por peso
            Array.Sort(edges, CompareEdges);

            // Reservamos memoria para el arreglo de subconjuntos
            int[] parent = new int[V];
            Array.Fill(parent, -1);

            // Inicializamos el número de aristas en el árbol de expansión mínima
            int edgeCount = 0;

            // Creamos un arreglo para guardar las aristas del árbol de expansión mínima
            Edge[] mst = new Edge[V - 1];

            // Iteramos sobre todas las aristas del grafo en orden ascendente de peso
            for (int i = 0; i < E && edgeCount < V - 1; i++)
            {
                // Obtenemos los vértices y el peso de la arista actual
                Edge currentEdge = edges[i];
                int src = currentEdge.src;
                int dest = currentEdge.dest;
                int weight = currentEdge.weight;

                // Si los vértices de la arista actual están en diferentes subconjuntos, los unimos
                if (FindSubset(parent, src) != FindSubset(parent, dest))
                {
                    UnionSubsets(parent, src, dest);

                    // Agregamos la arista actual al árbol de expansión mínima
                    mst[edgeCount] = currentEdge;
                    edgeCount++;
                }
            }

            // Imprimimos el árbol de expansión mínima
            Console.WriteLine("Árbol de expansión mínima:");
            for (int i = 0; i < V - 1; i++)
                Console.WriteLine(mst[i].src + " - " + mst[i].dest + " : " + mst[i].weight);
        }

        // Ejemplo de uso
        public static void Main()
        {
            int V = 4; // Número de vértices
            int E = 5; // Número de aristas
            Edge[] edges = new Edge[E]; // Arreglo de aristas

            // Inicializamos el grafo de ejemplo
            edges[0].src = 0;
            edges[0].dest = 1;
            edges[0].weight = 10
        }
        }
    }
}
