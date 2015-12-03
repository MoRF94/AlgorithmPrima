using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Vertex
    {
        private int x, y, number;

        public int X
        {
            get { return x; }
            set
            {
                checkX(value);
                x = value; 
            }
        }

        public int Y
        {
            get { return y; }
            set 
            {
                checkY(value);
                y = value; 
            }
        }

        public int Number
        {
            get { return number; }
            set 
            {
                checkVertexOfNumber(value);
                number = value; 
            }
        }

        private string exp = "The coordinates of the vertices have to be positive";

        private void checkY(int y)
        {
            if (y < 0)
                throw new Exception(exp);
        }

        private void checkX(int x)
        {
            if (x < 0)
                throw new Exception(exp);
        }

        private void checkVertexOfNumber(int numb)
        {
            if (Number < 0)
                throw new Exception("Vertex number must be greater than zero");
        }

        public Vertex(int Number, int X, int Y)
        {
            checkX(x);
            checkY(y);
            checkVertexOfNumber(Number);
            x = X;
            y = Y;
            number = Number;
        }
    }
}
