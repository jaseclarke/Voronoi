using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVoronoi
{
    //public class VoronoiByRegion
    //{
    //    private Rectangle _boundingBox;
    //    private readonly List<Point> _siteList = new List<Point>();
    //    private Random _rnd = new Random();

    //    public VoronoiByRegion(Rectangle boundingBox)
    //    {
    //        _boundingBox = boundingBox;
    //        CreateSite();
    //        CreateSite();
    //    }

    //    private void CreateSite()
    //    {
    //        int x = _boundingBox.X + _rnd.Next(_boundingBox.Width);
    //        int y = _boundingBox.Y + _rnd.Next(_boundingBox.Height);
    //        _siteList.Add(new Point(x,y));

    //        NearestRegion(new Point(2, 2), new Point(8, 6));
    //        NearestRegion(new Point(8, 6), new Point(2, 2));
    //    }

    //    private Region NearestRegion(Point primary, Point secondary)
    //    {
    //        Point midPoint = new Point((primary.X+secondary.X)/2, (primary.Y + secondary.Y) / 2);
    //        double bisectorGradient = -1 * ((double) primary.Y - secondary.Y) / ((double) primary.X - secondary.X);

    //        double intercept = midPoint.Y - bisectorGradient * midPoint.X;

    //        double xmin = _boundingBox.X;
    //        double ymin = _boundingBox.Y;
    //        double xmax = _boundingBox.X + _boundingBox.Width;
    //        double ymax = _boundingBox.Y + _boundingBox.Height;

    //        double yatxmin = bisectorGradient * xmin + intercept;
    //        double yatxmax = bisectorGradient * xmax + intercept;
    //        double xatymin = (ymin - intercept) / bisectorGradient;
    //        double xatymax = (ymax - intercept) / bisectorGradient;

    //        PointF p1 = yatxmin < ymax ? new PointF((float)xmin, (float)yatxmin) : new PointF((float)xatymin, (float)ymax);
    //        PointF p2 = yatxmax < ymax ? new PointF((float)xmax, (float)yatxmax) : new PointF((float)xatymax, (float)ymin);

    //        Console.WriteLine($"p1={p1},p2={p2}");
    //        return null;
    //    }
    //}
}
