using System;
using System.Collections.Generic;

#nullable disable

namespace DeathValley.Models
{
    public partial class Point
    {
        public int PointId { get; set; }
        public int ChartId { get; set; }
        public int PointX { get; set; }
        public int PointY { get; set; }

        public virtual UserData Chart { get; set; }
    }
}
