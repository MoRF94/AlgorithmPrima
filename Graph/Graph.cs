using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Graph
    {
        private List<Vertex> listVertex;
        private List<Edge> listEdge;
        private int[,] matrix;

        public Graph(List<Vertex> Vertex, List<Edge> Edge)
        {
            foreach (Vertex ver in Vertex)
                checkVertex(ver);
            foreach (Edge edge in Edge)
                checkNumberOfVertex(edge);

            listVertex = new List<Vertex>();
            listEdge = new List<Edge>();

            listVertex = Vertex;
            listEdge = Edge;
        }

        public Graph()
        {
            listVertex = new List<Vertex>();
            listEdge = new List<Edge>();
        }

        public List<Vertex> Vertex 
        { 
            get { return listVertex; }
            set 
            { 
                foreach(Vertex ver in value)
                    try
                    {
                        checkVertex(ver);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                listVertex = value; 
            }
        }
        
        public List<Edge> Edge 
        { 
            get { return listEdge; }
            set 
            {   
                foreach (Edge ed in value)
                    try
                    {
                        checkNumberOfVertex(ed);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                listEdge = value;

                foreach (Edge ed in value)
                    ed.Weight = CalculateWeight(listVertex[ed.FirstVertex].X, listVertex[ed.SecondVertex].X,
                                            listVertex[ed.FirstVertex].Y, listVertex[ed.SecondVertex].Y);
            }
        }

        public Vertex GetVertex(int index)
        {
            return listVertex[index];
        }

        public Edge GetEdge(int index)
        {
            return listEdge[index];
        }

        public void AddVertex(Vertex item)
        {
            checkVertex(item);

            this.listVertex.Add(item);
        }

        public void AddEdge(Edge item)
        {
            try
            {
                checkNumberOfVertex(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            item.Weight = CalculateWeight(listVertex[item.FirstVertex].X, listVertex[item.SecondVertex].X,
                                            listVertex[item.FirstVertex].Y, listVertex[item.SecondVertex].Y);
            this.listEdge.Add(item);            
        }

        public int[,] GetSingleMatrix()
        {
            int[,] matrix = new int[listVertex.Count, listVertex.Count];

            foreach (Edge ed in listEdge)
                matrix[ed.FirstVertex, ed.SecondVertex] = matrix[ed.SecondVertex, ed.FirstVertex] = 1;

            return matrix;
        }

        private void checkVertex(Vertex item)
        {
            foreach (Vertex ver in listVertex)
                if (item.Number == ver.Number)
                    throw new Exception("In the collection has a vertex with this number");
                else if (item.X == ver.X || item.Y == ver.Y)
                    throw new Exception("The coordinates of vertices should not coincide");
        }

        private void checkNumberOfVertex(Edge item)
        {
            bool conformity = false;
            foreach (int number in item.GetNumberOfVertex())
            {
                conformity = false;
                foreach (Vertex ver in listVertex)
                    if (number == ver.Number)
                    {
                        conformity = true;
                        break;
                    }
            }

            if (conformity == false)
                throw new Exception("Not found vertex. Check the number of vertices of the edge.");
        }

        public void InsertListEdge(List<int[]> ListEdge)
        {
            foreach (int[] ed in ListEdge)
                listEdge.Add(new Edge(ed[0], ed[1]));
        }

        public int[,] GetMatrix()
        {
            matrix = new int[listVertex.Count, listVertex.Count];

            foreach (Edge ed in listEdge)
                matrix[ed.FirstVertex, ed.SecondVertex] = matrix[ed.SecondVertex, ed.FirstVertex] = ed.Weight;

            return matrix;
        }

        private int CalculateWeight(int x, int x1, int y, int y1)
        {
            int value;

            if (x == x1)
            {
                value = Math.Abs(y - y1) / 10;
            }
            else if (y == y1)
            {
                value = Math.Abs(x - x1) / 10;
            }
            else
            {
                Double SQR1, SQR2;

                SQR1 = Math.Pow(Math.Abs(x - x1), 2.0);
                SQR2 = Math.Pow(Math.Abs(y - y1), 2.0);

                value = (int) Math.Sqrt(SQR1 + SQR2) / 10;
            }

            return value;
        }
    }
}
