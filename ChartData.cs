using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace DeathValley
{
    public class ChartData
    {
        public int[] labels;
        public Point[] points;

        public ChartData(int[] labels, Point[] points)
        {
            this.labels = labels;
            this.points = points;
        }
    }
}
