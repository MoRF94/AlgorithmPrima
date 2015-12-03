using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Algorithm
    {
        public Algorithm()
        {

        }

        public bool ChekMatrix(int[,] Matrix)
        {
            int iTotal = 0;
            bool[] bVisited = new bool[(int) Math.Sqrt((Matrix.Length))];
            Queue q = new Queue();
            q.Enqueue(0);
            bVisited[0] = true;

            do
            {
                int i = (int)q.Dequeue();
                iTotal++;
                for (int j = 0; j < (int) Math.Sqrt((Matrix.Length)); j++)

                    if (Matrix[i, j] != 0 && !bVisited[j])
                    {
                        q.Enqueue(j);
                        bVisited[j] = true;
                    }

            }while (q.Count != 0);
            if (iTotal == (int) Math.Sqrt((Matrix.Length)))
                return true;
            else
                return false;
        }

        public bool CheckWeightdge(int[,] Matrix)
        {
            for (int i = 0; i < (int)Math.Sqrt((Matrix.Length)); i++ )
                for (int j = i; j < (int)Math.Sqrt((Matrix.Length)); j++ )
                    if (Matrix[i, j] < 0)
                        return false;

            return true;
        }

        public class Prima
        {
            private int[,] sourceMatrix;
            private List<int[]> resultListEdge;
            private string log;

            public string Log
            {
                get { return log; }
            }

            public int[,] SourseMatrix
            {
                get { return sourceMatrix; }
                set { sourceMatrix = value; }
            }

            public List<int[]> ResultListEdge
            {
                get { return Calculate(); }
            }

            public Prima(int[,] Matrix)
            {
                if (Matrix.Length < 2)
                    throw new Exception("It must be 2 or more!");
                else if (new Algorithm().ChekMatrix(Matrix) == false)
                    throw new Exception("Weight of the edge should be greater than or equal to zero");
                else if (new Algorithm().ChekMatrix(Matrix) == false)
                    throw new Exception("Not all vertices are connected!");
                sourceMatrix = Matrix;
            }

            private void RecordLog(int rows, int column)
            {
                log += "Found minimal relative to the vertex edge " + rows + ".\r\n";
                log += "This edge " + rows + " - " + column + "\r\n";
                log += "Remove all the values of the rows  " + rows + " and " + column + " of the adjacency matrix.\r\n";
                log += "-------------------------------------\r\n";
            }

            private List<int[]> Calculate()
            {
                int[,] workingMatrix = sourceMatrix;
                resultListEdge = new List<int[]>();
                List<int> listLabelVertex = new List<int>();
                listLabelVertex.Add(0);

                int countVertex = (int) Math.Sqrt(workingMatrix.Length);

                while (resultListEdge.Count < countVertex - 1)
                {
                    int minimum = int.MaxValue,
                        currentRows = 0,
                        currentСolumn = 0;

                    for (int i = 0; i < listLabelVertex.Count; i++)
                    {
                        int j = listLabelVertex[i];
                        for (int k = 0; k < countVertex; k++)
                            if (workingMatrix[k, j] < minimum && workingMatrix[k, j] != 0)
                            {
                                minimum = workingMatrix[k, j];
                                currentСolumn = j;
                                currentRows = k;
                            }
                    }

                    for (int j = 0; j < countVertex; j++)
                    {
                        workingMatrix[currentRows, j] = 0;
                        workingMatrix[currentСolumn, j] = 0;
                    }

                    RecordLog(currentRows, currentСolumn);

                    listLabelVertex.Add(currentRows);
                    resultListEdge.Add(new int[2] {currentRows, currentСolumn});
                }
                return resultListEdge;
            }
        }
    }
}
