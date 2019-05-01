using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClipperLib;

namespace RegionVoronoi
{
    public class VoronoiByRegion
    {
        private Rectangle _boundingBox;
        private readonly List<PointF> _siteList = new List<PointF>();
        private readonly Random _rnd = new Random();

        public List<Tuple<PointF,List<PointF>>> Points { get; } = new List<Tuple<PointF, List<PointF>>>();

        public VoronoiByRegion(Rectangle boundingBox, int numSites)
        {
            _boundingBox = boundingBox;

            for (int i = 0; i < numSites; ++i)
            {
                CreateSite();
            }

            foreach (var site in _siteList)
            {
                AddRegion(new Point((int) site.X, (int) site.Y), CreateVoronoiRegion(site));
            }
        }

        private void AddRegion(Point primary, List<IntPoint> points)
        {
            Points.Add(new Tuple<PointF, List<PointF>>(primary, points.Select(p => new PointF((float) p.X,(float) p.Y)).ToList()));
        }

        private List<IntPoint> CreateVoronoiRegion(PointF primary)
        {
            Clipper c = new Clipper();

            var solution = new List<List<IntPoint>>();

            List<IntPoint> currentList = null;

            foreach (var site in _siteList)
            {
                if (Math.Abs(primary.X - site.X) < 1 && primary.Y - site.Y < 1) continue;
                if (Math.Abs(primary.X - site.X) < 1) continue;
                if (Math.Abs(primary.Y - site.Y) < 1) continue;

                var region = NearestRegion(c, primary, site);
                if (currentList == null)
                {
                    currentList = region;
                }
                else
                {
                    c.Clear();
                    c.AddPolygon(currentList, PolyType.ptSubject);
                    c.AddPolygon(region, PolyType.ptClip);
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
            _siteList.Add(new PointF((float)x, (float)y));
        }

        private void Test()
        {
        }

        private List<IntPoint> NearestRegion(Clipper c, PointF primary, PointF secondary)
        {
            PointF midPoint = new PointF((primary.X + secondary.X) / 2, (primary.Y + secondary.Y) / 2);
            float bisectorGradient = -1 * (primary.X - secondary.X) / (primary.Y - secondary.Y);

            float intercept = midPoint.Y - bisectorGradient * midPoint.X;

            float xmin = _boundingBox.X;
            float ymin = _boundingBox.Y;
            float xmax = _boundingBox.X + _boundingBox.Width;
            float ymax = _boundingBox.Y + _boundingBox.Height;

            float yatxmin = bisectorGradient * xmin + intercept;
            float yatxmax = bisectorGradient * xmax + intercept;
            float xatymin = (ymin - intercept) / bisectorGradient;
            float xatymax = (ymax - intercept) / bisectorGradient;

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

            bool left = isLeft(points[0], points[1], primary);

            var rectanglePoints = new List<PointF>
            {
                new PointF(xmin, ymin),
                new PointF(xmin, ymax),
                new PointF(xmax, ymin),
                new PointF(xmax, ymax)
            };


            rectanglePoints.RemoveAll(p => isLeft(points[0], points[1], p) != left);

            points.AddRange(rectanglePoints);

            points = points.OrderBy(p => Math.Atan2(primary.Y - p.Y, primary.X - p.X)).ToList();
            points.Add(points[0]);

            return points.Select(p => new IntPoint((int)p.X, (int)p.Y)).ToList();

            //Console.WriteLine($"n={points.Count};p1={points[0]},p2={points[1]}, left={left}");
        }

        public bool isLeft(PointF a, PointF b, PointF c)
        {
            return ((b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X)) > 0;
        }
    }
}
