using System;
using System.Collections.Generic;
using System.Drawing;

namespace RegionVoronoi
{
    public class Site : IEquatable<Site>
    {
        public PointF Position { get; set; }
        public Color Color { get; set; }
        public List<PointF> RegionPoints { get; set; }

        public override string ToString()
        {
            return $"Position = ({Position.X}, {Position.Y})";
        }

        public bool Equals(Site other) => other != null && Position == other.Position;
    }
}