using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Graph;
using System.Drawing.Drawing2D;

namespace AlgorithmPrima
{
    public partial class Form1 : Form
    {
        private Thread th;
        private Edge edge;
        private Graph.Graph sourseGraph, resultGraph;
        private Vertex vertex;
        private bool firstClickRM = true;
        private Tools tools;
        private Point _vertex;
        private Point mouseCurrentPosition;
        private Algorithm.Prima prima;
        private bool run = false;
        private int indexVertexTake;
        private bool vertexTake = false;

        public Form1()
        { 
            sourseGraph = new Graph.Graph();
            resultGraph = new Graph.Graph();
            tools = new Tools();
            _vertex = new Point();
            mouseCurrentPosition = new Point();
            InitializeComponent();
        }

        private void button_Run_Click(object sender, EventArgs e)
        {
            th = new Thread(runAlgorithm);
            th.IsBackground = true;
            
            th.Start();            
        }

        public void runAlgorithm()
        {
            try
            {
                prima = new Algorithm.Prima(sourseGraph.GetMatrix());
                resultGraph.InsertListEdge(prima.ResultListEdge);
                resultGraph.Vertex = sourseGraph.Vertex;
                run = true;
                sendEnableButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
                sendEnableButton();
            }          
        }

        private void sendEnableButton()
        {
            this.BeginInvoke ( (Action) (() => 
                {
                    if(run == true)
                    {
                        pictureBox_Graph.Enabled = false;
                        button_Run.Enabled = false;
                        button_SaveAs.Enabled = true;
                    }
                    else
                    {
                        pictureBox_Graph.Enabled = true;
                        button_Run.Enabled = true;
                        button_SaveAs.Enabled = false;
                    }
                }));
        }

        private void pictureBox_Graph_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (sourseGraph.Vertex.Count == 0
                    ||
                    tools.CheckLocationForVertex(e.Location.X, e.Location.Y, sourseGraph.Vertex) == false)
                {
                    vertex = new Vertex(sourseGraph.Vertex.Count, e.X, e.Y);
                    sourseGraph.AddVertex(vertex);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                foreach (Vertex ver in sourseGraph.Vertex)
                    if (tools.CheckHitVertex(ver, e.X, e.Y) == true)
                    {
                        if (firstClickRM == true)
                        {                            
                            firstClickRM = false;
                            _vertex.X = sourseGraph.Vertex.IndexOf(ver);
                            return;
                        }
                        else
                        {
                            firstClickRM = true;
                            _vertex.Y = sourseGraph.Vertex.IndexOf(ver);
                            foreach (Edge ed in sourseGraph.Edge)
                                if (ed.FirstVertex == _vertex.X && ed.SecondVertex == _vertex.Y)
                                    return;
                            try
                            {
                                edge = new Edge(_vertex.X, _vertex.Y);
                                sourseGraph.AddEdge(edge);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error!");
                            }
                            _vertex = new Point();
                            return;
                        }
                    }
                firstClickRM = true;
            }
            pictureBox_Graph.Refresh();
        }
        
        private void pictureBox_Graph_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                foreach (Vertex ver in sourseGraph.Vertex)
                    if (tools.CheckHitVertex(ver, e.X, e.Y) == true)
                    {
                        indexVertexTake = sourseGraph.Vertex.IndexOf(ver);
                        vertexTake = true;
                        break;
                    }
            }
        }

        private void pictureBox_Graph_MouseUp(object sender, MouseEventArgs e)
        {
            vertexTake = false;            
            pictureBox_Graph.Refresh();
        }

        private void pictureBox_Graph_MouseMove(object sender, MouseEventArgs e)
        {
            int width = pictureBox_Graph.Size.Width, height = pictureBox_Graph.Size.Height;

            if (vertexTake == true)
            {
                int[] location;

                if (width - 23 > e.Location.X && 23 < e.Location.X && height - 23 > e.Location.Y && 23 < e.Location.Y)
                {
                    location = tools.CheckAppliedToVertex(sourseGraph.Vertex, e.X, e.Y, indexVertexTake);
                }
                else
                {
                    location = tools.CheckAppliedToBorder(e.X, e.Y, pictureBox_Graph.Size.Height, pictureBox_Graph.Size.Width);
                }

                sourseGraph.Vertex[indexVertexTake].X = location[0];
                sourseGraph.Vertex[indexVertexTake].Y = location[1];
            }
            else if (!firstClickRM)
            {
                mouseCurrentPosition = e.Location;
            }

            pictureBox_Graph.Refresh();
        }

        private void pictureBox_Graph_Paint(object sender, PaintEventArgs e)
        {
            DrawGraph draw = new DrawGraph();

            draw.ColorEdge = Color.Gold;

            if (!firstClickRM)
                draw.DrawTempEdge(e.Graphics,
                    new Point(sourseGraph.Vertex[_vertex.X].X, sourseGraph.Vertex[_vertex.X].Y),
                    mouseCurrentPosition);

            draw.PaintGraph(e.Graphics, sourseGraph);

            draw.ColorEdge = Color.Green;

            draw.PaintGraph(e.Graphics, resultGraph);

            if(vertexTake == true)
                draw.DrawRegion(e.Graphics, pictureBox_Graph.Width, pictureBox_Graph.Height);                       
        }

        private void timer_UpdateInfo_Tick(object sender, EventArgs e)
        {
            if (run == true)
            {
                textBox_Log.Text = prima.Log;
                pictureBox_Graph.Refresh();
            }
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            newSheet();
        }

        private void newSheet()
        {
            indexVertexTake = new int();
            vertexTake = false;
            pictureBox_Graph.Image = null;
            textBox_Log.Clear();
            run = false;
            sourseGraph = new Graph.Graph();
            resultGraph = new Graph.Graph();
            tools = new Tools();
            _vertex = new Point();
            mouseCurrentPosition = new Point();
            pictureBox_Graph.Enabled = true;
            button_Run.Enabled = true;
        }

        private void button_SaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog d = new SaveFileDialog();
            d.DefaultExt = ".xml";
            d.Filter = "Graph in format (*.xml)| *.xml|Save log (*.txt)| *.txt|All types | *.*";
            
            if (d.ShowDialog() != DialogResult.OK) 
                return;
            try
            {
                if (d.FilterIndex == 1)
                    tools.SaveGraphXML(d.FileName, sourseGraph);
                else if (d.FilterIndex == 2)
                    tools.SaveLog(d.FileName, prima.Log);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
        }

        private void button_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.DefaultExt = ".xml";
            d.Filter = "Graph in format (*.xml)| *.xml|All types | *.*";

            if (d.ShowDialog() != DialogResult.OK) 
                return;

            if (d.DefaultExt == "xml")
                try
                {
                    tools.OpenGraphXML(d.FileName, sourseGraph);
                    newSheet();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!");
                }

            pictureBox_Graph.Refresh();            
        }
    }

    public class DrawGraph
    {
        public DrawGraph() { }

        private Graph.Graph graph;
        private Color color = Color.Gold;

        public Color ColorEdge
        {
            get { return color; }
            set { color = value; }
        }

        public void PaintGraph(Graphics graphics, Graph.Graph Graph)
        {
            graph = Graph;

            DrawEdge(graphics);
            DrawVertex(graphics);            
        }

        public void DrawTempEdge(Graphics item, Point firstPosition, Point currentLocation)
        {
            item.DrawLine(new Pen(Brushes.Red, 5),
                    firstPosition.X, firstPosition.Y,
                    currentLocation.X, currentLocation.Y);
        }

        public void DrawRegion(Graphics item, int Width, int Height)
        {
            Pen pen = new Pen(Brushes.Blue, 2);
            pen.DashStyle = DashStyle.Dash;

            foreach (Vertex ver in graph.Vertex)
            {
                item.DrawEllipse(pen, ver.X - 20, ver.Y - 20, 40, 40);
            }

            item.DrawRectangle(pen, 1, 1, Width - 4, Height - 4);
        }

        private void DrawVertex(Graphics item)
        {
            foreach (Vertex ver in graph.Vertex)
            {
                item.FillEllipse(Brushes.Red, ver.X - 15, ver.Y - 15, 30, 30);
            }

            foreach (Vertex ver in graph.Vertex)
            {
                    Point positionLabel = new Point();

                    if (graph.Vertex.IndexOf(ver) < 9)
                    {
                        positionLabel.X = ver.X - 9;
                        positionLabel.Y = ver.Y - 13;
                    }
                    else if (graph.Vertex.IndexOf(ver) >= 9 && graph.Vertex.IndexOf(ver) < 99)
                    {
                        positionLabel.X = ver.X - 13;
                        positionLabel.Y = ver.Y - 13;
                    }
                    else
                    {
                        positionLabel.X = ver.X - 18;
                        positionLabel.Y = ver.Y - 13;
                    }

                    item.DrawString(ver.Number.ToString(),
                        new Font("Microsoft Sans Serif", 14.0F),
                        Brushes.White, positionLabel.X, positionLabel.Y);
            }
        }

        private void DrawEdge(Graphics graphics)
        {
            Pen pen = new Pen(color, 3);
            pen.DashStyle = DashStyle.Dash;

            foreach (Edge edge in graph.Edge)
            {
                Vertex firstVertex = graph.Vertex[edge.FirstVertex],
                    finalVertex = graph.Vertex[edge.SecondVertex];

                graphics.DrawLine(pen, 
                    firstVertex.X, firstVertex.Y, 
                    finalVertex.X, finalVertex.Y);
            }
        }
    }
}
