using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using ClipperLib;
using MigraDoc.DocumentObjectModel;
using MigraDoc.RtfRendering;

namespace RegionVoronoi
{
    public class VoronoiByRegion
    {
        private const int printedImageWidth = 720;
        private const int printedImageHeight = 720;

        public int ImageOffset { get; set; } = 40;

        private readonly Rectangle _boundingBox;

        private readonly Random _rnd = new Random();

        public List<Site> Sites { get; } = new List<Site>();

        public VoronoiByRegion(Rectangle boundingBox, int numSites)
        {
            _boundingBox = boundingBox;

            for (int i = 0; i < numSites; ++i)
            {
                CreateSite();
            }
            Calculate();
        }

        public void CreateDocument(string fileName)
        {
            var doc = new Document();

            Section section = doc.AddSection();

            var mainImagePath = Path.Combine(TempFolder, "mainDiagram.png");

            SavePictureAsImage(mainImagePath);

            var image = section.AddImage(mainImagePath);

            foreach (var siteImagePath in CreateSiteImages())
            {
                var siteImage = section.AddImage(siteImagePath);
            }

            RtfDocumentRenderer rtfRender = new RtfDocumentRenderer();

            rtfRender.Render(doc, fileName, TempFolder);
        }

        private Tuple<int, int> SiteImageSize(Site s, int fullWidth, int fullHeight)
        {
            int minX = s.RegionPoints.Min(pt => pt.X);
            int maxX = s.RegionPoints.Max(pt => pt.X);
            int minY = s.RegionPoints.Min(pt => pt.Y);
            int maxY = s.RegionPoints.Max(pt => pt.Y);

            double xscale = ((double)fullWidth) / ((double)_boundingBox.Width);
            double yscale = ((double)fullHeight) / ((double)_boundingBox.Height);

            int imageWidth = (int)(xscale * (double) (maxX - minX));
            int imageHeight = (int)(yscale * (double)(maxY - minY));

            return new Tuple<int, int>(imageWidth, imageHeight);
        }

        private string TempFolder
        {
            get
            {
                var tempFolder = Path.Combine(Path.GetTempPath(), "Voronoi");

                if (!Directory.Exists(tempFolder))
                {
                    Directory.CreateDirectory(tempFolder);
                }

                return tempFolder;
            }
        }

        public void CreateSiteImage(string imageFileName, Site s)
        {
            var imageSize = SiteImageSize(s, printedImageWidth, printedImageHeight);

            using (Bitmap bm = new Bitmap(imageSize.Item1+4*ImageOffset, imageSize.Item2+4*ImageOffset))
            {
                using (Graphics g = Graphics.FromImage(bm))
                {
                    DrawSitePicture(s, g, true, true, printedImageWidth, printedImageHeight);
                    bm.Save(imageFileName, ImageFormat.Png);
                }
            }
        }

        private List<string> CreateSiteImages()
        {
            List<string> pathList = new List<string>();
            for (int i = 0; i < Sites.Count; ++i)
            {
                string siteImagePath = Path.Combine(TempFolder, $@"SitePicture{i + 1}.png");
                pathList.Add(siteImagePath);
                CreateSiteImage(siteImagePath, Sites[i]);
            }
            return pathList;
        }

        public void SavePictureAsImage(string fileName)
        {
            using (Bitmap bm = new Bitmap(printedImageWidth, printedImageHeight))
            {
                using (Graphics g = Graphics.FromImage(bm))
                {
                    DrawPicture(g,true,true,false, printedImageWidth, printedImageHeight);
                    bm.Save(fileName,ImageFormat.Png);
                }
            }
        }

        public void DrawSitePicture(Site site, Graphics g, bool fillShapes, bool showOutlines, int fullWidth, int fullHeight)
        {
            double xscale = ((double)fullWidth) / ((double)_boundingBox.Width);
            double yscale = ((double)fullHeight) / ((double)_boundingBox.Height);

            g.InterpolationMode = InterpolationMode.High;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int minX = site.RegionPoints.Min(pt => pt.X);
            int minY = site.RegionPoints.Min(pt => pt.Y);

            //var offsetPoints = site.RegionPoints.Select(pt => new Point(pt.X - minX + 5, pt.Y - minY + 5)).ToArray();
            var offsetPoints = site.RegionPoints
                .Select(pt => new Point((int)(xscale * ((double)pt.X - minX))+ 2*ImageOffset, (int)(yscale * ((double)pt.Y - minY)+ 2*ImageOffset))).ToArray();

            if (fillShapes)
            {

                g.FillPolygon(new SolidBrush(site.Color), offsetPoints);

                if (showOutlines)
                {
                    g.DrawPolygon(Pens.Black, offsetPoints);
                }

                if (showOutlines)
                {
                    ClipperOffset offset = new ClipperOffset();

                    offset.AddPath(offsetPoints.Select(op => new IntPoint(op.X,op.Y)).ToList(),JoinType.jtMiter,EndType.etClosedLine);

                    List<List<IntPoint>> solution = new List<List<IntPoint>>();
                    offset.Execute(ref solution,ImageOffset);

                    if (solution.Count > 0)
                    {
                        var offsetPoly = solution[0];
                        g.DrawPolygon(Pens.Red, offsetPoly.Select(ip => new Point((int)ip.X, (int)ip.Y)).ToArray());
                    }
                }
            }
            else
            {
                g.DrawPolygon(new Pen(site.Color), offsetPoints);
            }

            //if (showPoints)
            //{
            //    g.FillRectangle(Brushes.Blue, (float)(site.Position.X - 2.5), (float)(site.Position.Y - 2.5), 5, 5);
            //}
        }


        public void DrawPicture(Graphics g, bool fillShapes, bool showOutlines, bool showPoints, int width, int height)
        {
            double xscale = ((double)width) / ((double)_boundingBox.Width);
            double yscale = ((double)height) / ((double)_boundingBox.Height);


            g.InterpolationMode = InterpolationMode.High;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            foreach (var site in Sites)
            {
                var scaledPoints = site.RegionPoints
                    .Select(pt => new Point((int) (xscale * (double) pt.X), (int) (yscale * (double) pt.Y))).ToArray();

                if (fillShapes)
                {
                    g.FillPolygon(new SolidBrush(site.Color), scaledPoints);

                    if (showOutlines)
                    {
                        g.DrawPolygon(Pens.Black, scaledPoints);
                    }
                }
                else
                {
                    g.DrawPolygon(new Pen(site.Color), scaledPoints);
                }

                if (showPoints)
                {
                    g.FillRectangle(Brushes.Blue, (float)(site.Position.X - 2.5), (float)(site.Position.Y - 2.5), 5, 5);
                }
            }
        }

        public void Calculate()
        {
            foreach (var site in Sites)
            {
                AddRegion(site, CreateVoronoiRegion(site));
            }

            ConsolidateNearbyPoints();
        }

        private void ConsolidateNearbyPoints()
        {
            var allPoints = Sites.SelectMany(s => s.RegionPoints).Distinct().ToList();

            foreach (var point in allPoints)
            {
                var nearbyPoints = allPoints.Where(p => Distance(p, point) < 5).ToList();

                if (nearbyPoints.Count > 1)
                {
                    foreach (var nearbyPoint in nearbyPoints)
                    {
                        if (nearbyPoint == point) continue;

                        foreach (var site in Sites)
                        {
                            for (int i = 0; i < site.RegionPoints.Count; ++i)
                            {
                                if (site.RegionPoints[i] == nearbyPoint)
                                {
                                    site.RegionPoints[i] = point;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void AddRegion(Site primary, List<IntPoint> points)
        {
            primary.RegionPoints = points.Select(p => new Point((int) p.X, (int) p.Y)).ToList();
        }

        public List<Site> HaveCommonEdges(Site s)
        {
            var sitesWithCommonEdges = new List<Site>();
            foreach (var otherSite in Sites)
            {
                if (otherSite.Equals(s)) continue;
                foreach (var point in s.RegionPoints)
                {
                    if (otherSite.RegionPoints.Contains(point))
                    {
                        sitesWithCommonEdges.Add(otherSite);
                        break;
                    }
                }
            }

            return sitesWithCommonEdges;
        }

        private List<IntPoint> CreateVoronoiRegion(Site primary)
        {
            Clipper c = new Clipper();

            var solution = new List<List<IntPoint>>();

            List<IntPoint> currentList = null;

            foreach (var site in Sites)
            {
                if (primary.Equals(site)) continue;

                var region = NearestRegion(primary, site);
                if (currentList == null)
                {
                    currentList = region;
                }
                else
                {
                    c.Clear();
                    c.AddPath(currentList, PolyType.ptSubject, true);
                    c.AddPath(region, PolyType.ptClip, true);
                    //c.AddPolygon(currentList, PolyType.ptSubject);
                    //c.AddPolygon(region, PolyType.ptClip);
                    c.Execute(ClipType.ctIntersection, solution);

                    currentList = solution[0];
                }
            }

            return currentList;
        }

        private void CreateSite()
        {
            int x = _boundingBox.X + _rnd.Next(_boundingBox.Width);
            int y = _boundingBox.Y + _rnd.Next(_boundingBox.Height);
            Sites.Add(new Site { Position = new PointF(x,y) });
        }

        private double Distance(PointF p1, PointF p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
        public Site NearestSite(Point p)
        {
            var nearest = Sites.OrderBy(s => Distance(s.Position, new PointF(p.X, p.Y))).First();
            return nearest;
        }

        private List<IntPoint> NearestRegion(Site primary, Site secondary)
        {
            PointF midPoint = new PointF((primary.Position.X + secondary.Position.X) / 2, (primary.Position.Y + secondary.Position.Y) / 2);

            bool verticalBisector = Math.Abs(primary.Position.Y - secondary.Position.Y) < 0.1;

            float bisectorGradient =  verticalBisector?0:-1 * (primary.Position.X - secondary.Position.X) / (primary.Position.Y - secondary.Position.Y);

            float intercept = verticalBisector?midPoint.Y:midPoint.Y - bisectorGradient * midPoint.X;

            float xmin = _boundingBox.X;
            float ymin = _boundingBox.Y;
            float xmax = _boundingBox.X + _boundingBox.Width;
            float ymax = _boundingBox.Y + _boundingBox.Height;

            float yatxmin = verticalBisector ? -1 : bisectorGradient * xmin + intercept;
            float yatxmax = verticalBisector ? -1 : bisectorGradient * xmax + intercept;
            float xatymin = verticalBisector ? midPoint.X : (ymin - intercept) / bisectorGradient;
            float xatymax = verticalBisector ? midPoint.X : (ymax - intercept) / bisectorGradient;

            PointF ptAtXMin = new PointF(xmin, yatxmin);
            PointF ptAtXMax = new PointF(xmax, yatxmax);
            PointF ptAtYMin = new PointF(xatymin, ymin);
            PointF ptAtYMax = new PointF(xatymax, ymax);

            var points = new List<PointF>();

            if (ptAtXMin.Y >= ymin && ptAtXMin.Y <= ymax)
            {
                points.Add(ptAtXMin);
            }
            if (ptAtXMax.Y >= ymin && ptAtXMax.Y <= ymax)
            {
                points.Add(ptAtXMax);
            }
            if (ptAtYMin.X >= xmin && ptAtYMin.X <= xmax)
            {
                points.Add(ptAtYMin);
            }
            if (ptAtYMax.X >= xmin && ptAtYMax.X <= xmax)
            {
                points.Add(ptAtYMax);
            }

            bool left = IsLeft(points[0], points[1], primary.Position);

            var rectanglePoints = new List<PointF>
            {
                new PointF(xmin, ymin),
                new PointF(xmin, ymax),
                new PointF(xmax, ymin),
                new PointF(xmax, ymax)
            };


            rectanglePoints.RemoveAll(p => IsLeft(points[0], points[1], p) != left);

            points.AddRange(rectanglePoints);

            points = points.OrderBy(p => Math.Atan2(primary.Position.Y - p.Y, primary.Position.X - p.X)).ToList();
            points.Add(points[0]);

            return points.Select(p => new IntPoint((int)p.X, (int)p.Y)).ToList();
        }

        public bool IsLeft(PointF a, PointF b, PointF c)
        {
            return ((b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X)) > 0;
        }
    }
}
