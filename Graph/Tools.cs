using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Graph
{
    public class Tools
    {
        public Tools() { }

        public int[] CheckAppliedToVertex(List<Vertex> Vertex, int currX, int currY, int currentIndex)
        {
            List<Vertex> vertex = Vertex;

            int[] location = new int[2];
            bool fl = false;

            foreach (Vertex ver in vertex)
            {
                if (Math.Abs(ver.X - currX) <= 40 && Math.Abs(ver.Y - currY) <= 40 && vertex.IndexOf(ver) != currentIndex)
                {
                    fl = true;

                    if (currX <= ver.X)
                    {
                        location[0] = ver.X - 40;
                        location[1] = currY;
                    }
                    else if (currX >= ver.X)
                    {
                        location[0] = ver.X + 40;
                        location[1] = currY;
                    }
                    else if (currY >= ver.Y)
                    {
                        location[1] = ver.Y + 40;
                        location[0] = currX;
                    }
                    else if (currY <= ver.Y)
                    {
                        location[1] = ver.Y + 40;
                        location[0] = currX;
                    }
                }
            }

            if (fl == true)
            {
                fl = false;
                return location;
            }
            else
                return new int[2] { currX, currY };
        }

        public int[] CheckAppliedToBorder(int currX, int currY, int h, int w)
        {
            int[] location = new int[2];

            if (currX <= 23 && currY <= 23)
            {
                location[0] = 21;
                location[1] = 21;
            }
            else if (currX <= 23 && currY >= h - 23)
            {
                location[0] = 21;
                location[1] = h - 23;
            }
            if (currX >= w - 23 && currY <= 23)
            {
                location[0] = w - 23;
                location[1] = 21;
            }
            else if (currX >= w - 23 && currY >= h - 23)
            {
                location[0] = h - 23;
                location[1] = h - 23;
            }
            else if (currX <= 23 || currX >= w - 23)
            {
                location[1] = currY;

                if (currX <= 23)
                    location[0] = 21;
                else if (currX >= w - 23)
                    location[0] = w - 23;
            }
            else if (currY <= 23 || currY >= h - 23)
            {
                location[0] = currX;

                if (currY <= 23)
                    location[1] = 21;
                else if (currY >= h - 23)
                    location[1] = h - 23;
            }

            return location;
        }

        public bool CheckHitVertex(Vertex ver, int currX, int currY)
        {
            if (Math.Abs(ver.X - currX) <= 15 && Math.Abs(ver.Y - currY) <= 15)
            {
                return true;
            }
            else
                return false;
        }

        public bool CheckLocationForVertex(int currX, int currY, List<Vertex> Vertex)
        {
            List<Vertex> vertex = Vertex;

            if (471 - 15 > currX && 15 < currX && 471 - 15 > currY && 15 < currY)
                foreach (Vertex ver in vertex)
                    if (Math.Abs(ver.X - currX) < 30 && Math.Abs(ver.Y - currY) < 30)
                        return true;

            return false;
        }

        public void SaveGraphXML(string FileName, Graph Graph)
        {
            XmlTextWriter w = new XmlTextWriter(FileName, Encoding.Unicode);
            w.Formatting = Formatting.Indented;
            w.WriteStartDocument();

            w.WriteStartElement("Graph");
            w.WriteStartElement("Adjacency_matrix");
            w.WriteAttributeString("Count_Vertex", XmlConvert.ToString(Graph.Vertex.Count));

            int[,] matrix = Graph.GetMatrix();

            for (int i = 0; i < Graph.Vertex.Count; i++)
            {
                w.WriteStartElement("Rows" + (i + 1));

                for (int j = 0; j < Graph.Vertex.Count; j++)
                    w.WriteAttributeString("Cell" + (j + 1), XmlConvert.ToString(matrix[i, j]));

                w.WriteEndElement();
            }

            w.WriteEndElement();

            w.WriteStartElement("Vertices");
            w.WriteAttributeString("Count", XmlConvert.ToString(Graph.Vertex.Count));

            int I = 0;

            foreach (Vertex ver in Graph.Vertex)
            {
                w.WriteStartElement("Vertex" + (I));

                w.WriteAttributeString("X", XmlConvert.ToString(ver.X));
                w.WriteAttributeString("Y", XmlConvert.ToString(ver.Y));

                w.WriteEndElement();

                I++;
            }

            w.WriteEndElement();

            w.WriteStartElement("Edges");
            w.WriteAttributeString("Count", XmlConvert.ToString(Graph.Edge.Count));

            I = 0;

            foreach (Edge edge in Graph.Edge)
            {
                w.WriteStartElement("Edge" + (I + 1));

                w.WriteAttributeString("FirstVertex", XmlConvert.ToString(edge.FirstVertex));
                w.WriteAttributeString("SecondsVertex", XmlConvert.ToString(edge.SecondVertex));

                w.WriteEndElement();

                I++;
            }

            w.WriteEndElement();

            w.WriteEndElement();
            w.WriteEndDocument();
            w.Close();
        }

        public void SaveLog(string FileName, string Log)
        {
            string log = Log, fileName = FileName;

            System.IO.File.WriteAllText(fileName, log);
        }

        public void OpenGraphXML(string FileName, Graph Graph)
        {
            XmlTextReader xmlTextReader = new XmlTextReader(FileName);
            xmlTextReader.ReadToFollowing("Graph");

            xmlTextReader.ReadToFollowing("Vertices");
            int countVertex = XmlConvert.ToInt32(xmlTextReader.GetAttribute("Count"));

            for (int i = 0; i < countVertex; i++)
            {
                xmlTextReader.ReadToFollowing("Vertex" + i);

                Graph.AddVertex(new Vertex(
                    i, 
                    int.Parse(xmlTextReader.GetAttribute("X")), 
                    int.Parse(xmlTextReader.GetAttribute("Y"))));
            }

            xmlTextReader.ReadToFollowing("Edges");

            int cR = XmlConvert.ToInt32(xmlTextReader.GetAttribute("Count"));

            for (int i = 0; i < cR; i++)
            {
                xmlTextReader.ReadToFollowing("Edge" + (i + 1));

                Graph.AddEdge(new Edge(
                    int.Parse(xmlTextReader.GetAttribute("SecondsVertex")),
                    int.Parse(xmlTextReader.GetAttribute("FirstVertex"))));
            }

            xmlTextReader.Close();
        }
    }
}
