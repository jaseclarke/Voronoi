using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RandomColorGenerator;
using RegionVoronoi;

namespace SimpleVoronoi
{
    public partial class Form1 : Form
    {
        private Bitmap _drawingArea;

        private int DrawingWidth => pictureBox1.Width;
        private int DrawingHeight => pictureBox1.Height;

        private VoronoiByRegion _voronoi;

        public Form1()
        {
            InitializeComponent();

            CreateNewDiagram();
        }

        private void AssignColors()
        {
            if (randomColCB.Checked)
            {
                AssignRandomColors();
            }
            else
            {
                AssignMinimumColors();
            }
        }

        private void AssignRandomColors()
        {
            var colors = RandomColor.GetColors(ColorScheme.Random, fillCB.Checked ? Luminosity.Light : Luminosity.Dark,
                _voronoi.Sites.Count);
            for (int i = 0; i < _voronoi.Sites.Count; ++i)
            {
                _voronoi.Sites[i].Color = colors[i];
            }
        }

        private void DumpSites()
        {
            using (var sw = new StreamWriter(@"c:\temp\sites.txt"))
            {
                foreach (var site in _voronoi.Sites)
                {
                    sw.Write($"({site.Position.X},{site.Position.Y}) : ");
                    foreach (var point in site.RegionPoints)
                    {
                        sw.Write($"({point.X},{point.Y}) ");
                    }
                    sw.WriteLine();
                }
            }
        }
        private void AssignMinimumColors()
        {
            var colors = RandomColor.GetColors(ColorScheme.Random, fillCB.Checked ? Luminosity.Light : Luminosity.Dark,
                _voronoi.Sites.Count);
            _voronoi.Sites.ForEach(s => s.Color = Color.Green);
            DumpSites();
            foreach (var site in _voronoi.Sites)
            {
                var sitesWithCommonEdges = _voronoi.HaveCommonEdges(site);
                var colorsUsedInCommonSites = sitesWithCommonEdges.Where(s => s.Color != Color.Green).Select(s => s.Color).Distinct();
                var nextColor = colors.First(c => !colorsUsedInCommonSites.Contains(c));

                site.Color = nextColor;
            }
        }

        private void AssignRandomColor(Site s)
        {
            s.Color = RandomColor.GetColor(ColorScheme.Random, fillCB.Checked ? Luminosity.Light : Luminosity.Dark);
        }

        private void CreateNewDiagram()
        {
            CreateDrawingArea();
            _voronoi = new VoronoiByRegion(pictureBox1.Bounds, (int) numberOfPoints.Value);
            AssignColors(); 
            DrawPicture(_voronoi);
        }

        private void DrawPicture(VoronoiByRegion rg)
        {
            Graphics g = Graphics.FromImage(_drawingArea);
            g.InterpolationMode = InterpolationMode.High;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            foreach (var site in rg.Sites)
            {
                if (fillCB.Checked)
                {
                    g.FillPolygon(new SolidBrush(site.Color), site.RegionPoints.ToArray());

                    if (showOutlines.Checked)
                    {
                        g.DrawPolygon(Pens.Black, site.RegionPoints.ToArray());
                    }
                }
                else
                {
                    g.DrawPolygon(new Pen(site.Color), site.RegionPoints.ToArray());
                }

                if (showPoints.Checked)
                {
                    g.FillRectangle(Brushes.Blue, (float) (site.Position.X - 2.5), (float) (site.Position.Y - 2.5), 5, 5);
                }
            }

            pictureBox1.Image = _drawingArea;
            pictureBox1.Refresh();
        }

        private void CreateDrawingArea()
        {
            _drawingArea = new Bitmap(DrawingWidth,DrawingHeight);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateNewDiagram();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog {Filter = @"JPG Image|*.jpg"};
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd.FileName,ImageFormat.Jpeg);
            }
        }

        private void ReColourBtn_Click(object sender, EventArgs e)
        {
            AssignColors();
            DrawPicture(_voronoi);
        }

        public void RemoveSite(Site s)
        {
            if (_voronoi.Sites.Count > 2)
            {
                _voronoi.Sites.Remove(s);
                _voronoi.Calculate();
                CreateDrawingArea();
                DrawPicture(_voronoi);
            }
        }

        public void AddSite(Point newLocation)
        {
            Site newSite = new Site {Position = new PointF(newLocation.X, newLocation.Y)};
            AssignRandomColor(newSite);
            if (_voronoi.Sites.Contains(newSite)) return;

            _voronoi.Sites.Add(newSite);
            _voronoi.Calculate();
            CreateDrawingArea();
            DrawPicture(_voronoi);
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (deleteEdit.Checked)
            {
                Site s = _voronoi.NearestSite(e.Location);
                RemoveSite(s);
            }

            if (addEdit.Checked)
            {
                AddSite(e.Location);
            }

            if (noneEdit.Checked)
            {
                Site s = _voronoi.NearestSite(e.Location);
                var connectedSites = _voronoi.HaveCommonEdges(s);
            }
        }
    }
}
