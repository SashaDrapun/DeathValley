using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace DeathValley
{
    public class ChartData
    {
        public ChartData(string[] labels, Point[] points)
        {
            Labels = labels;
            Points = points;
        }

        public string[] Labels { get => labels; set => labels = value; }
        public Point[] Points { get => points; set => points = value; }

        private string[] labels;
        private Point[] points;
    }
}
