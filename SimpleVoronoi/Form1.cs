using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RandomColorGenerator;
using RegionVoronoi;

namespace SimpleVoronoi
{
    public partial class Form1 : Form
    {
        private List<Point> _sites = new List<Point>();

        private Bitmap _drawingArea = null;

        private int Width => pictureBox1.Width;
        private int Height => pictureBox1.Height;

        private SolidBrush[] _brushes;
        private Color[] _colors;

        private Random _rnd;
        public Form1()
        {
            InitializeComponent();

            //pictureBox1.AutoSize = true;

            _rnd = new Random();

            CreateDiagram();


        }

        private void CreateBrushes(int numPoints)
        {
             _colors = RandomColor.GetColors(ColorScheme.Random, Luminosity.Light, numPoints);
            _brushes = _colors.Select(c => new SolidBrush(c)).ToArray();
        }
        private void CreateDiagram()
        {
            CreateBrushes((int) numberOfPoints.Value);

            CreateDrawingArea();

            VoronoiByRegion rg = new VoronoiByRegion(pictureBox1.Bounds, (int) numberOfPoints.Value);

            Graphics g = Graphics.FromImage(_drawingArea);
            g.InterpolationMode = InterpolationMode.High;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int index = 0;
            foreach (var point in rg.Points)
            {

                if (fillCB.Checked)
                {
                    g.FillPolygon(_brushes[index % (int)numberOfPoints.Value], point.Item2.ToArray());

                    if (showOutlines.Checked)
                    {
                        g.DrawPolygon(Pens.Black, point.Item2.ToArray());
                    }
                }
                else
                {
                    g.DrawPolygon(new Pen(_colors[index % (int) numberOfPoints.Value]), point.Item2.ToArray());
                }

                if (showPoints.Checked)
                {
                    g.FillRectangle(Brushes.Blue, point.Item1.X, point.Item1.Y, 5, 5);
                }
                ++index;
            }
            //BuildPoints();
            //CreateBrushes();
            //BruteForceVoronoi();
            pictureBox1.Image = _drawingArea;
            pictureBox1.Refresh();
        }

        private void CreateDrawingArea()
        {
            _drawingArea = new Bitmap(Width,Height);
        }

        private double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        private void BuildPoints()
        {
            _sites.Clear();
            Graphics g = Graphics.FromImage(_drawingArea);
            for (int i = 0; i < 20; ++i)
            {
                int x1 = (int)Math.Floor(_rnd.NextDouble() * Width);
                int y1 = (int)Math.Floor(_rnd.NextDouble() * Height);
                int x2 = (int)Math.Floor(_rnd.NextDouble() * Width);
                int y2 = (int)Math.Floor(_rnd.NextDouble() * Height);

                _sites.Add(new Point(x1,y1));

 //               g.FillEllipse(new SolidBrush(Color.Blue), x1, y1, 5,5);
            }
        }

        private void BruteForceVoronoi()
        {
            _drawingArea = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(_drawingArea);

            for (int i = 0; i < Width; ++i)
            {
                for (int j = 0; j < Height; ++j)
                {
                    Point cp = new Point(i,j);
                    double minDist = double.MaxValue;
                    int nearestSiteIndex = 0;
                    for (int s=0; s<_sites.Count; ++s)
                    {
                        if (Distance(_sites[s],cp) < minDist)
                        {
                            nearestSiteIndex = s;
                            minDist = Distance(_sites[s], cp);
                        }
                    }

 //                   _drawingArea.LockBits()

                    _drawingArea.SetPixel(i, j, _colors[nearestSiteIndex]);
//                    g.FillRectangle(_brushes[nearestSiteIndex % 20], p.X, p.Y, 1, 1);
                    // or with spaces
                }
            }
        }

        private void  pictureBox1_Resize(object sender, EventArgs e)
        {
           // CreateDiagram();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateDiagram();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog {Filter = @"JPG Image|*.jpg"};
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd.FileName,ImageFormat.Jpeg);
            }
        }
    }
}
