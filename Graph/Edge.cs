using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Edge
    {
        private struct Number
        {
            public int FirstVertex;
            public int SecondVertex;
        };

        private int weight;
        private Number numb;

        public Edge(int FirstVertex, int SecondVertex)
        {
            if (FirstVertex == SecondVertex)
                throw new Exception("Error! FirstVertex and FinalVertex need not be equal");

            numb = new Number();

            numb.FirstVertex = FirstVertex;
            numb.SecondVertex = SecondVertex;
            weight = 1;
        }

        public List<int> GetNumberOfVertex()
        {
            List<int> listNumber = new List<int>();
            listNumber.Add(numb.FirstVertex);
            listNumber.Add(numb.SecondVertex);

            return listNumber;
        }

        public int FirstVertex { get { return numb.FirstVertex; } set { numb.FirstVertex = value; } }
        public int SecondVertex { get { return numb.SecondVertex; } set { numb.SecondVertex = value; } }
        
        public int Weight 
        { 
            get { return weight; } 
            set 
            {
                if (weight < 0)
                    throw new Exception("Error! Weight edges must be positive");
                weight = value; 
            } 
        }
    }
}
